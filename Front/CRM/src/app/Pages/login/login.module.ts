import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { FormLoginModule } from 'src/app/Components/form-login/form-login.module';
import { MatSnackBarModule } from '@angular/material/snack-bar';


@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule,
    FormLoginModule,
    MatSnackBarModule
  ], exports:[LoginComponent]
})
export class LoginModule { }
