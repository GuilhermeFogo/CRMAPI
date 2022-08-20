import { MenuModule } from './../../Components/menu/menu.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';


@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    CommonModule,
    MenuModule,
    MatSnackBarModule
  ], exports:[DashboardComponent]
})
export class DashboardModule { }
