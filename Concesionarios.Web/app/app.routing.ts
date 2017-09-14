import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
//import { HomeComponent } from './components/home.component';
import { ConcesionarioComponent } from './components/concesionario.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'concesionario', pathMatch: 'full' },
    //{ path: 'home', component: HomeComponent },
    { path: 'concesionario', component: ConcesionarioComponent }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);