import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuarioListadoRoutingModule } from './usuario-listado-routing.module';
import {UsuarioListadoComponent} from "./usuario-listado.component";


@NgModule({
  declarations: [
    UsuarioListadoComponent
  ],
  imports: [
    CommonModule,
    UsuarioListadoRoutingModule
  ],
  providers:[],
  exports: [UsuarioListadoComponent],
  bootstrap: [UsuarioListadoComponent]
})
export class UsuarioListadoModule { }
