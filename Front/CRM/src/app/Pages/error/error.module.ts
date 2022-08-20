import { MenuModule } from './../../Components/menu/menu.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorComponent } from './error.component';



@NgModule({
  declarations: [
    ErrorComponent
  ],
  imports: [
    CommonModule,
    MenuModule
  ], exports:[ErrorComponent]
})
export class ErrorModule { }
