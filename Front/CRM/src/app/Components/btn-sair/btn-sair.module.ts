import { MatButtonModule } from '@angular/material/button';
import { BtnSairComponent } from './btn-sair.component';
import { NgModule } from '@angular/core';
import {MatIconModule} from '@angular/material/icon'
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [BtnSairComponent],
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule
  ], exports:[
    BtnSairComponent
  ]
})
export class BtnSairModule { }
