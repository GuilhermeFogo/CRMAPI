import { SelectRoleComponent } from './select-role.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatSelectModule} from '@angular/material/select';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [SelectRoleComponent],
  imports: [
    CommonModule, 
    MatSelectModule,
    ReactiveFormsModule
  ], exports:[SelectRoleComponent]
})
export class SelectRoleModule { }
