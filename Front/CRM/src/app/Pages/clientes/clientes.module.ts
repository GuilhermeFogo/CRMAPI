import { MenuModule } from 'src/app/Components/menu/menu.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientesComponent } from '../clientes/clientes.component';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { FormClienteModule } from 'src/app/Components/form-cliente/form-cliente.module';
import { MatDialogModule } from '@angular/material/dialog';
import { MatExpansionModule } from '@angular/material/expansion';
import {MatGridListModule} from '@angular/material/grid-list';


@NgModule({
  declarations: [
    ClientesComponent
  ],
  imports: [
    CommonModule,
    MenuModule,
    MatButtonModule,
    MatSnackBarModule,
    MenuModule,
    FormClienteModule,
    MatDialogModule,
    MatExpansionModule,
    MatGridListModule
  ], exports:[
    ClientesComponent
  ]
})
export class ClientesModule { }
