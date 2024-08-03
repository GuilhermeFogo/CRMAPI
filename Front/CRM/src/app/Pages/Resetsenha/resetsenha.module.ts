import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResetsenhaComponent } from './resetsenha.component';
import { FormResetModule } from 'src/app/Components/form-reset/form-reset.module';
import { ConfirmPassModule } from 'src/app/Components/confirm-pass/confirm-pass.module';
import { DefinePassModule } from 'src/app/Components/define-pass/define-pass.module';



@NgModule({
  declarations: [
    ResetsenhaComponent
  ],
  imports: [
    CommonModule,
    FormResetModule,
    ConfirmPassModule,
    DefinePassModule
  ]
})
export class ResetsenhaModule { }
