"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var concesionario_service_1 = require("../Service/concesionario.service");
var forms_1 = require("@angular/forms");
var ng2_bs3_modal_1 = require("ng2-bs3-modal/ng2-bs3-modal");
var enum_1 = require("../Shared/enum");
var global_1 = require("../Shared/global");
var ConcesionarioComponent = (function () {
    function ConcesionarioComponent(fb, _concesionarioService) {
        this.fb = fb;
        this._concesionarioService = _concesionarioService;
        this.indLoading = false;
    }
    ConcesionarioComponent.prototype.ngOnInit = function () {
        this.concesionarioFrm = this.fb.group({
            Id: [''],
            Nombre: ['', forms_1.Validators.required],
            Direccion: ['']
        });
        this.LoadConcesionarios();
    };
    ConcesionarioComponent.prototype.LoadConcesionarios = function () {
        var _this = this;
        this.indLoading = true;
        this._concesionarioService.get(global_1.Global.BASE_CONCESIONARIO_ENDPOINT)
            .subscribe(function (concesionarios) { _this.concesionarios = concesionarios; _this.indLoading = false; }, function (error) { return _this.msg = error; });
    };
    ConcesionarioComponent.prototype.addConcesionario = function () {
        this.dbops = enum_1.DBOperation.create;
        this.SetControlsState(true);
        this.modalTitle = "Añadir nuevo Concesionario";
        this.modalBtnTitle = "Añadir";
        this.concesionarioFrm.reset();
        this.modal.open();
    };
    ConcesionarioComponent.prototype.editConcesionario = function (id) {
        this.dbops = enum_1.DBOperation.update;
        this.SetControlsState(true);
        this.modalTitle = "Modificar Concesionario";
        this.modalBtnTitle = "Modificar";
        this.concesionario = this.concesionarios.filter(function (x) { return x.Id == id; })[0];
        this.concesionarioFrm.setValue(this.concesionario);
        this.modal.open();
    };
    ConcesionarioComponent.prototype.deleteConcesionario = function (id) {
        this.dbops = enum_1.DBOperation.delete;
        this.SetControlsState(false);
        this.modalTitle = "¿Está seguro que desea eliminarlo?";
        this.modalBtnTitle = "Eliminar";
        this.concesionario = this.concesionarios.filter(function (x) { return x.Id == id; })[0];
        this.concesionarioFrm.setValue(this.concesionario);
        this.modal.open();
    };
    ConcesionarioComponent.prototype.SetControlsState = function (isEnable) {
        isEnable ? this.concesionarioFrm.enable() : this.concesionarioFrm.disable();
    };
    ConcesionarioComponent.prototype.onSubmit = function (formData) {
        var _this = this;
        this.msg = "";
        switch (this.dbops) {
            case enum_1.DBOperation.create:
                this._concesionarioService.post(global_1.Global.BASE_CONCESIONARIO_ENDPOINT, formData._value).subscribe(function (data) {
                    _this.msg = "Concesionario añadido.";
                    _this.LoadConcesionarios();
                    _this.modal.dismiss();
                }, function (error) {
                    _this.msg = error;
                });
                break;
            case enum_1.DBOperation.update:
                this._concesionarioService.put(global_1.Global.BASE_CONCESIONARIO_ENDPOINT, formData._value.Id, formData._value).subscribe(function (data) {
                    _this.msg = "Concesionario actualizado.";
                    _this.LoadConcesionarios();
                    _this.modal.dismiss();
                }, function (error) {
                    _this.msg = error;
                });
                break;
            case enum_1.DBOperation.delete:
                this._concesionarioService.delete(global_1.Global.BASE_CONCESIONARIO_ENDPOINT, formData._value.Id).subscribe(function (data) {
                    _this.msg = "Concesionario eliminado.";
                    _this.LoadConcesionarios();
                    _this.modal.dismiss();
                }, function (error) {
                    _this.msg = error;
                });
                break;
        }
    };
    return ConcesionarioComponent;
}());
__decorate([
    core_1.ViewChild('modal'),
    __metadata("design:type", ng2_bs3_modal_1.ModalComponent)
], ConcesionarioComponent.prototype, "modal", void 0);
ConcesionarioComponent = __decorate([
    core_1.Component({
        templateUrl: 'app/Components/concesionario.component.html'
    }),
    __metadata("design:paramtypes", [forms_1.FormBuilder, concesionario_service_1.ConcesionarioService])
], ConcesionarioComponent);
exports.ConcesionarioComponent = ConcesionarioComponent;
//# sourceMappingURL=concesionario.component.js.map