import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormResetComponent } from './form-reset.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';



@NgModule({
  declarations: [
    FormResetComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatInputModule
  ], 
  exports: [FormResetComponent]
})
export class FormResetModule { }
