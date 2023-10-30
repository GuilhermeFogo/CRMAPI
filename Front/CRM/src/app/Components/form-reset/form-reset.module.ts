import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormResetComponent } from './form-reset.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';



@NgModule({
  declarations: [
    FormResetComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatInputModule,
    MatIconModule
  ], 
  exports: [FormResetComponent]
})
export class FormResetModule { }
