import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuComponent } from './menu.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { BtnSairModule } from '../btn-sair/btn-sair.module';


@NgModule({
  declarations: [MenuComponent],
  imports: [
    CommonModule,
    MatButtonModule,
    BtnSairModule,
    MatIconModule
  ], exports:[MenuComponent]
})
export class MenuModule { }
