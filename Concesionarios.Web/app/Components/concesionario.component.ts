import { Component, OnInit, ViewChild } from '@angular/core';
import { ConcesionarioService } from '../Service/concesionario.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { IConcesionario } from '../Models/concesionario';
import { DBOperation } from '../Shared/enum';
import { Observable } from 'rxjs/Rx';
import { Global } from '../Shared/global';

@Component({

    templateUrl: 'app/Components/concesionario.component.html'

})

export class ConcesionarioComponent implements OnInit {
    @ViewChild('modal') modal: ModalComponent;
    concesionarios: IConcesionario[];
    concesionario: IConcesionario;
    msg: string;
    indLoading: boolean = false;
    concesionarioFrm: FormGroup;
    dbops: DBOperation;
    modalTitle: string;
    modalBtnTitle: string;

    constructor(private fb: FormBuilder, private _concesionarioService: ConcesionarioService) { }

    ngOnInit(): void {

        this.concesionarioFrm = this.fb.group({
            Id: [''],
            Nombre: ['', Validators.required],
            Direccion: ['']
        });

        this.LoadConcesionarios();
    }

    LoadConcesionarios(): void {
        this.indLoading = true;
        this._concesionarioService.get(Global.BASE_CONCESIONARIO_ENDPOINT)
            .subscribe(concesionarios => { this.concesionarios = concesionarios; this.indLoading = false; },
            error => this.msg = <any>error);
    }

    addConcesionario() {
        this.dbops = DBOperation.create;
        this.SetControlsState(true);
        this.modalTitle = "Añadir nuevo Concesionario";
        this.modalBtnTitle = "Añadir";
        this.concesionarioFrm.reset();
        this.modal.open();
    }

    editConcesionario(id: number) {
        this.dbops = DBOperation.update;
        this.SetControlsState(true);
        this.modalTitle = "Modificar Concesionario";
        this.modalBtnTitle = "Modificar";
        this.concesionario = this.concesionarios.filter(x => x.Id == id)[0];
        this.concesionarioFrm.setValue(this.concesionario);
        this.modal.open();
    }

    deleteConcesionario(id: number) {
        this.dbops = DBOperation.delete;
        this.SetControlsState(false);
        this.modalTitle = "¿Está seguro que desea eliminarlo?";
        this.modalBtnTitle = "Eliminar";
        this.concesionario = this.concesionarios.filter(x => x.Id == id)[0];
        this.concesionarioFrm.setValue(this.concesionario);
        this.modal.open();
    }

    SetControlsState(isEnable: boolean) {
        isEnable ? this.concesionarioFrm.enable() : this.concesionarioFrm.disable();
    }

    onSubmit(formData: any) {
        this.msg = "";

        switch (this.dbops) {
            case DBOperation.create:
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

            case DBOperation.update:
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

            case DBOperation.delete:
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

        }
    }
}

