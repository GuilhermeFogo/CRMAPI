import { ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SelectOpoComponent } from './select-opo.component';



@NgModule({
  declarations: [
    SelectOpoComponent
  ],
  imports: [
    CommonModule,
    MatSelectModule,
    ReactiveFormsModule
  ], exports:[SelectOpoComponent]
})
export class SelectOpoModule { }
