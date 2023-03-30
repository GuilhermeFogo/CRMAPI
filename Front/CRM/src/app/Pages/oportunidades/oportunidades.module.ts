import { FormOpoModule } from './../../Components/form-opo/form-opo.module';
import { FormOpoComponent } from './../../Components/form-opo/form-opo.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MenuModule } from './../../Components/menu/menu.module';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OportunidadesComponent } from '../oportunidades/oportunidades.component';
import { FormClienteModule } from 'src/app/Components/form-cliente/form-cliente.module';



@NgModule({
  declarations: [
    OportunidadesComponent
  ],
  imports: [
    CommonModule,
    MatButtonModule,
    MatSnackBarModule,
    MenuModule,
    FormClienteModule,
    MatDialogModule,
    FormOpoModule
  ], 
  exports:[OportunidadesComponent]
})
export class OportunidadesModule { }
