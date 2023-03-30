import { SelectAtivoModule } from './../select-ativo/select-ativo.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormOpoComponent } from './form-opo.component';
import { SelectProductModule } from '../select-product/select-product.module';
import { SelectOpoModule } from '../select-opo/select-opo.module';
import { MatInputModule } from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';


@NgModule({
  declarations: [
    FormOpoComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatFormFieldModule,
    SelectAtivoModule,
    SelectProductModule,
    SelectOpoModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  exports:[FormOpoComponent]
})
export class FormOpoModule { }
