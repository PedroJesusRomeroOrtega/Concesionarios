import { ICoche } from "./coche";

export interface IConcesionario {
    Id: number,
    Nombre: string,
    Direccion: string,
    Coches: ICoche[]
}