import { Component, OnInit, ViewChild } from '@angular/core';
import { ConcesionarioService } from '../Service/concesionario.service';
import { CocheService } from '../Service/coche.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { IConcesionario } from '../Models/concesionario';
import { ICoche } from '../Models/coche';
import { DBOperation } from '../Shared/enum';
import { Observable } from 'rxjs/Rx';
import { Global } from '../Shared/global';

@Component({

    templateUrl: 'app/Components/concesionario.component.html'

})

export class ConcesionarioComponent implements OnInit {
    @ViewChild('modal') modal: ModalComponent;
    @ViewChild('modal2') modal2: ModalComponent;
    concesionarios: IConcesionario[];
    concesionario: IConcesionario;
    coches: ICoche[];
    coche: ICoche;
    activeRow: number = 0;
    msg: string;
    indLoading: boolean = false;
    indLoadingCoche: boolean = false;
    concesionarioFrm: FormGroup;
    cocheFrm: FormGroup;
    dbops: DBOperation;
    modalTitle: string;
    modalBtnTitle: string;
    modalCocheTitle: string;
    modalBtnCocheTitle: string;

    constructor(private fb: FormBuilder, private _concesionarioService: ConcesionarioService, private _cocheService: CocheService) { }

    ngOnInit(): void {

        this.concesionarioFrm = this.fb.group({
            Id: [''],
            Nombre: ['', Validators.required],
            Direccion: ['']
        });

        this.cocheFrm = this.fb.group({
            Id: [''],
            Matricula: ['', Validators.required],
            Kilometros: [''],
            IdConcesionario: [''],
            IdMarca: ['']
        });

        this.LoadConcesionarios();
    }

    LoadConcesionarios(): void {
        this.indLoading = true;
        this._concesionarioService.get(Global.BASE_CONCESIONARIO_ENDPOINT)
            .subscribe(concesionarios => { this.concesionarios = concesionarios; this.indLoading = false; },
            error => this.msg = <any>error);
    }

    detailConcesionario(id: number) {
        this.indLoadingCoche = true;
        this.activeRow = id;
        this._cocheService.get(Global.BASE_COCHE_ENDPOINT + 'CocheDelConcesionario/' + id)
            .subscribe(coches => {
                this.coches = coches;
                this.indLoadingCoche = false;
            },
            error => this.msg = <any>error);
    }

    addConcesionario() {
        this.dbops = DBOperation.createConcesionario;
        this.SetControlsState(true);
        this.modalTitle = "Añadir nuevo Concesionario";
        this.modalBtnTitle = "Añadir";
        this.concesionarioFrm.reset();
        this.modal.open();
    }

    editConcesionario(id: number) {
        this.dbops = DBOperation.updateConcesionario;
        this.SetControlsState(true);
        this.modalTitle = "Modificar Concesionario";
        this.modalBtnTitle = "Modificar";
        this.concesionario = this.concesionarios.filter(x => x.Id == id)[0];
        this.concesionarioFrm.setValue(this.concesionario);
        this.modal.open();
    }

    deleteConcesionario(id: number) {
        this.dbops = DBOperation.deleteConcesionario;
        this.SetControlsState(false);
        this.modalTitle = "¿Está seguro que desea eliminarlo?";
        this.modalBtnTitle = "Eliminar";
        this.concesionario = this.concesionarios.filter(x => x.Id == id)[0];
        this.concesionarioFrm.setValue(this.concesionario);
        this.modal.open();
    }

    addCoche() {
        this.dbops = DBOperation.createCoche;
        this.SetControlsStateCoche(true);
        this.modalCocheTitle = "Nuevo coche";
        this.modalBtnCocheTitle = "Añadir";
        this.cocheFrm.reset();
        this.modal2.open();
    }

    editCoche(id: number) {
        this.dbops = DBOperation.updateCoche;
        this.SetControlsStateCoche(true);
        this.modalCocheTitle = "Modificar coche";
        this.modalBtnCocheTitle = "Modificar";
        this.coche = this.coches.filter(x => x.Id == id)[0];
        this.cocheFrm.setValue(this.coche);
        this.modal2.open();
    }

    deleteCoche(id: number) {
        this.dbops = DBOperation.deleteCoche;
        this.SetControlsStateCoche(true);
        this.modalCocheTitle = "¿Está seguro que desea eliminarlo?";
        this.modalBtnCocheTitle = "Eliminar";
        this.coche = this.coches.filter(x => x.Id == id)[0];
        this.cocheFrm.setValue(this.coche);
        this.modal2.open();
    }

    SetControlsState(isEnable: boolean) {
        isEnable ? this.concesionarioFrm.enable() : this.concesionarioFrm.disable();
    }

    SetControlsStateCoche(isEnable: boolean) {
        isEnable ? this.cocheFrm.enable() : this.cocheFrm.disable();
    }

    onSubmit(formData: any) {
        this.msg = "";

        switch (this.dbops) {
            case DBOperation.createConcesionario:
                this._concesionarioService.post(Global.BASE_CONCESIONARIO_ENDPOINT, formData._value).subscribe(
                    data => {
                        this.msg = "Concesionario añadido.";
                        this.LoadConcesionarios();
                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;

            case DBOperation.updateConcesionario:
                this._concesionarioService.put(Global.BASE_CONCESIONARIO_ENDPOINT, formData._value.Id, formData._value).subscribe(
                    data => {
                        this.msg = "Concesionario actualizado.";
                        this.LoadConcesionarios();
                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;

            case DBOperation.deleteConcesionario:
                this._concesionarioService.delete(Global.BASE_CONCESIONARIO_ENDPOINT, formData._value.Id).subscribe(
                    data => {
                        this.msg = "Concesionario eliminado.";
                        this.LoadConcesionarios();
                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;

            case DBOperation.createCoche:
                this._concesionarioService.post(Global.BASE_COCHE_ENDPOINT, formData._value).subscribe(
                    data => {
                        this.msg = "Coche añadido.";
                        this.detailConcesionario(this.activeRow);
                        this.modal2.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;

            case DBOperation.updateCoche:
                this._cocheService.put(Global.BASE_COCHE_ENDPOINT, formData._value.Id, formData._value).subscribe(
                    data => {
                        this.msg = "Coche actualizado.";
                        this.detailConcesionario(this.activeRow);
                        this.modal2.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;

            case DBOperation.deleteCoche:
                this._cocheService.delete(Global.BASE_COCHE_ENDPOINT, formData._value.Id).subscribe(
                    data => {
                        this.msg = "Coche eliminado.";
                        this.detailConcesionario(this.activeRow);
                        this.modal2.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;
        }
    }
}

