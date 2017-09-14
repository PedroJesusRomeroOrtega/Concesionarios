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
var coche_service_1 = require("../Service/coche.service");
var forms_1 = require("@angular/forms");
var ng2_bs3_modal_1 = require("ng2-bs3-modal/ng2-bs3-modal");
var enum_1 = require("../Shared/enum");
var global_1 = require("../Shared/global");
var ConcesionarioComponent = (function () {
    function ConcesionarioComponent(fb, _concesionarioService, _cocheService) {
        this.fb = fb;
        this._concesionarioService = _concesionarioService;
        this._cocheService = _cocheService;
        this.activeRow = 0;
        this.indLoading = false;
        this.indLoadingCoche = false;
    }
    ConcesionarioComponent.prototype.ngOnInit = function () {
        this.concesionarioFrm = this.fb.group({
            Id: [''],
            Nombre: ['', forms_1.Validators.required],
            Direccion: ['']
        });
        this.cocheFrm = this.fb.group({
            Id: [''],
            Matricula: ['', forms_1.Validators.required],
            Kilometros: [''],
            IdConcesionario: [''],
            IdMarca: ['']
        });
        this.LoadConcesionarios();
    };
    ConcesionarioComponent.prototype.LoadConcesionarios = function () {
        var _this = this;
        this.indLoading = true;
        this._concesionarioService.get(global_1.Global.BASE_CONCESIONARIO_ENDPOINT)
            .subscribe(function (concesionarios) { _this.concesionarios = concesionarios; _this.indLoading = false; }, function (error) { return _this.msg = error; });
    };
    ConcesionarioComponent.prototype.detailConcesionario = function (id) {
        var _this = this;
        this.indLoadingCoche = true;
        this.activeRow = id;
        this._cocheService.get(global_1.Global.BASE_COCHE_ENDPOINT + 'CocheDelConcesionario/' + id)
            .subscribe(function (coches) {
            _this.coches = coches;
            _this.indLoadingCoche = false;
        }, function (error) { return _this.msg = error; });
    };
    ConcesionarioComponent.prototype.addConcesionario = function () {
        this.dbops = enum_1.DBOperation.createConcesionario;
        this.SetControlsState(true);
        this.modalTitle = "Añadir nuevo Concesionario";
        this.modalBtnTitle = "Añadir";
        this.concesionarioFrm.reset();
        this.modal.open();
    };
    ConcesionarioComponent.prototype.editConcesionario = function (id) {
        this.dbops = enum_1.DBOperation.updateConcesionario;
        this.SetControlsState(true);
        this.modalTitle = "Modificar Concesionario";
        this.modalBtnTitle = "Modificar";
        this.concesionario = this.concesionarios.filter(function (x) { return x.Id == id; })[0];
        this.concesionarioFrm.setValue(this.concesionario);
        this.modal.open();
    };
    ConcesionarioComponent.prototype.deleteConcesionario = function (id) {
        this.dbops = enum_1.DBOperation.deleteConcesionario;
        this.SetControlsState(false);
        this.modalTitle = "¿Está seguro que desea eliminarlo?";
        this.modalBtnTitle = "Eliminar";
        this.concesionario = this.concesionarios.filter(function (x) { return x.Id == id; })[0];
        this.concesionarioFrm.setValue(this.concesionario);
        this.modal.open();
    };
    ConcesionarioComponent.prototype.addCoche = function () {
        this.dbops = enum_1.DBOperation.createCoche;
        this.SetControlsStateCoche(true);
        this.modalCocheTitle = "Nuevo coche";
        this.modalBtnCocheTitle = "Añadir";
        this.cocheFrm.reset();
        this.modal2.open();
    };
    ConcesionarioComponent.prototype.editCoche = function (id) {
        this.dbops = enum_1.DBOperation.updateCoche;
        this.SetControlsStateCoche(true);
        this.modalCocheTitle = "Modificar coche";
        this.modalBtnCocheTitle = "Modificar";
        this.coche = this.coches.filter(function (x) { return x.Id == id; })[0];
        this.cocheFrm.setValue(this.coche);
        this.modal2.open();
    };
    ConcesionarioComponent.prototype.deleteCoche = function (id) {
        this.dbops = enum_1.DBOperation.deleteCoche;
        this.SetControlsStateCoche(true);
        this.modalCocheTitle = "¿Está seguro que desea eliminarlo?";
        this.modalBtnCocheTitle = "Eliminar";
        this.coche = this.coches.filter(function (x) { return x.Id == id; })[0];
        this.cocheFrm.setValue(this.coche);
        this.modal2.open();
    };
    ConcesionarioComponent.prototype.SetControlsState = function (isEnable) {
        isEnable ? this.concesionarioFrm.enable() : this.concesionarioFrm.disable();
    };
    ConcesionarioComponent.prototype.SetControlsStateCoche = function (isEnable) {
        isEnable ? this.cocheFrm.enable() : this.cocheFrm.disable();
    };
    ConcesionarioComponent.prototype.onSubmit = function (formData) {
        var _this = this;
        this.msg = "";
        switch (this.dbops) {
            case enum_1.DBOperation.createConcesionario:
                this._concesionarioService.post(global_1.Global.BASE_CONCESIONARIO_ENDPOINT, formData._value).subscribe(function (data) {
                    _this.msg = "Concesionario añadido.";
                    _this.LoadConcesionarios();
                    _this.modal.dismiss();
                }, function (error) {
                    _this.msg = error;
                });
                break;
            case enum_1.DBOperation.updateConcesionario:
                this._concesionarioService.put(global_1.Global.BASE_CONCESIONARIO_ENDPOINT, formData._value.Id, formData._value).subscribe(function (data) {
                    _this.msg = "Concesionario actualizado.";
                    _this.LoadConcesionarios();
                    _this.modal.dismiss();
                }, function (error) {
                    _this.msg = error;
                });
                break;
            case enum_1.DBOperation.deleteConcesionario:
                this._concesionarioService.delete(global_1.Global.BASE_CONCESIONARIO_ENDPOINT, formData._value.Id).subscribe(function (data) {
                    _this.msg = "Concesionario eliminado.";
                    _this.LoadConcesionarios();
                    _this.modal.dismiss();
                }, function (error) {
                    _this.msg = error;
                });
                break;
            case enum_1.DBOperation.createCoche:
                this._concesionarioService.post(global_1.Global.BASE_COCHE_ENDPOINT, formData._value).subscribe(function (data) {
                    _this.msg = "Coche añadido.";
                    _this.detailConcesionario(_this.activeRow);
                    _this.modal2.dismiss();
                }, function (error) {
                    _this.msg = error;
                });
                break;
            case enum_1.DBOperation.updateCoche:
                this._cocheService.put(global_1.Global.BASE_COCHE_ENDPOINT, formData._value.Id, formData._value).subscribe(function (data) {
                    _this.msg = "Coche actualizado.";
                    _this.detailConcesionario(_this.activeRow);
                    _this.modal2.dismiss();
                }, function (error) {
                    _this.msg = error;
                });
                break;
            case enum_1.DBOperation.deleteCoche:
                this._cocheService.delete(global_1.Global.BASE_COCHE_ENDPOINT, formData._value.Id).subscribe(function (data) {
                    _this.msg = "Coche eliminado.";
                    _this.detailConcesionario(_this.activeRow);
                    _this.modal2.dismiss();
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
__decorate([
    core_1.ViewChild('modal2'),
    __metadata("design:type", ng2_bs3_modal_1.ModalComponent)
], ConcesionarioComponent.prototype, "modal2", void 0);
ConcesionarioComponent = __decorate([
    core_1.Component({
        templateUrl: 'app/Components/concesionario.component.html'
    }),
    __metadata("design:paramtypes", [forms_1.FormBuilder, concesionario_service_1.ConcesionarioService, coche_service_1.CocheService])
], ConcesionarioComponent);
exports.ConcesionarioComponent = ConcesionarioComponent;
//# sourceMappingURL=concesionario.component.js.map