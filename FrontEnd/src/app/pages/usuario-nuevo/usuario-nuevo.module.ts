import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {UsuarioNuevoComponent} from "./usuario-nuevo.component";
import {UsuarioNuevoRoutingModule} from "./usuario-nuevo-routing.module";



@NgModule({
  declarations: [UsuarioNuevoComponent],
  imports: [
    UsuarioNuevoRoutingModule,
    CommonModule
  ],
  exports: [UsuarioNuevoComponent],
  providers: [],
  bootstrap: [UsuarioNuevoComponent]
})
export class UsuarioNuevoModule { }
