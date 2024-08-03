import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DefinePassComponent } from '../define-pass/define-pass.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';



@NgModule({
  declarations: [
    DefinePassComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatInputModule,
    MatIconModule
  ],
  exports:[
    DefinePassComponent
  ]
})
export class DefinePassModule { }
