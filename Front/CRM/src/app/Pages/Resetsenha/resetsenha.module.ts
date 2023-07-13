import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResetsenhaComponent } from './resetsenha.component';
import { FormResetModule } from 'src/app/Components/form-reset/form-reset.module';



@NgModule({
  declarations: [
    ResetsenhaComponent
  ],
  imports: [
    CommonModule,
    FormResetModule
  ]
})
export class ResetsenhaModule { }
