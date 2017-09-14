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
//import { ConcesionarioService } from '../Service/concesionario.service';
var coche_service_1 = require("../Service/coche.service");
var forms_1 = require("@angular/forms");
var ng2_bs3_modal_1 = require("ng2-bs3-modal/ng2-bs3-modal");
var global_1 = require("../Shared/global");
var CocheComponent = (function () {
    //modalTitle: string;
    //modalBtnTitle: string;
    function CocheComponent(fb, _cocheService) {
        this.fb = fb;
        this._cocheService = _cocheService;
        this.activeRow = 0;
        //indLoading: boolean = false;
        this.indLoadingCoche = false;
    }
    CocheComponent.prototype.ngOnInit = function () {
        this.cocheFrm = this.fb.group({
            Id: [''],
            Matricula: ['', forms_1.Validators.required],
            Kilometros: ['']
        });
        //this.LoadConcesionarios();
    };
    CocheComponent.prototype.detailConcesionario = function (id) {
        var _this = this;
        this.indLoadingCoche = true;
        this.activeRow = id;
        this._cocheService.get(global_1.Global.BASE_COCHE_ENDPOINT + 'CocheDelConcesionario/' + id)
            .subscribe(function (coches) {
            _this.coches = coches;
            _this.indLoadingCoche = false;
        }, function (error) { return _this.msg = error; });
    };
    return CocheComponent;
}());
__decorate([
    core_1.ViewChild('modal'),
    __metadata("design:type", ng2_bs3_modal_1.ModalComponent)
], CocheComponent.prototype, "modal", void 0);
CocheComponent = __decorate([
    core_1.Component({
        templateUrl: 'app/Components/concesionario.component.html'
    }),
    __metadata("design:paramtypes", [forms_1.FormBuilder, coche_service_1.CocheService])
], CocheComponent);
exports.CocheComponent = CocheComponent;
//# sourceMappingURL=coche.component.js.map