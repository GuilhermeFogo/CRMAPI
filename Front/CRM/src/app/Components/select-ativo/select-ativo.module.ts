import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SelectAtivoComponent } from '../select-ativo/select-ativo.component';
import { MatSelectModule } from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    SelectAtivoComponent
  ],
  imports: [
    CommonModule, 
    MatSelectModule,
    ReactiveFormsModule
  ], exports:[SelectAtivoComponent]
})
export class SelectAtivoModule { }
