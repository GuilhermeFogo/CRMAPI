import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmPassComponent } from '../confirm-pass/confirm-pass.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';



@NgModule({
  declarations: [
    ConfirmPassComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatInputModule,
    MatIconModule
  ],
  exports:[
    ConfirmPassComponent
  ]
})
export class ConfirmPassModule { }
