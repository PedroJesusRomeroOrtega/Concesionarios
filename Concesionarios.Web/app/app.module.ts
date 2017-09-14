import { NgModule } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';
import { HttpModule } from '@angular/http';
import { routing } from './app.routing';

import { ConcesionarioService } from './Service/concesionario.service'
import { CocheService } from './Service/coche.service'
import { ConcesionarioComponent } from './components/concesionario.component';
//import { CocheComponent } from './components/coche.component';

@NgModule({
    imports: [BrowserModule, ReactiveFormsModule, HttpModule, routing, Ng2Bs3ModalModule],
    declarations: [AppComponent, ConcesionarioComponent],
    providers: [{ provide: APP_BASE_HREF, useValue: '/' }, ConcesionarioService, CocheService],
    bootstrap: [AppComponent]
})

export class AppModule { }