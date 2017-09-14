"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
//import { HomeComponent } from './components/home.component';
var concesionario_component_1 = require("./components/concesionario.component");
var appRoutes = [
    { path: '', redirectTo: 'concesionario', pathMatch: 'full' },
    //{ path: 'home', component: HomeComponent },
    { path: 'concesionario', component: concesionario_component_1.ConcesionarioComponent }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map