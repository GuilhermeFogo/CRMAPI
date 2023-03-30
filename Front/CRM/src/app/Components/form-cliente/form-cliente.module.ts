import { SelectAtivoModule } from './../select-ativo/select-ativo.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormClienteComponent } from './form-cliente.component';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';



@NgModule({
  declarations: [FormClienteComponent],
  imports: [
    CommonModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatInputModule,
    MatDialogModule,
    SelectAtivoModule
  ], exports:[FormClienteComponent]
})
export class FormClienteModule { }
