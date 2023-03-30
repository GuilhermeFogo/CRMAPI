import { SelectProductComponent } from './select-product.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatSelectModule} from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [SelectProductComponent],
  imports: [
    CommonModule, 
    MatSelectModule,
    ReactiveFormsModule
  ], exports:[SelectProductComponent]
})
export class SelectProductModule { }
