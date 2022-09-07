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
    MatDialogModule
  ], 
  exports:[OportunidadesComponent]
})
export class OportunidadesModule { }
