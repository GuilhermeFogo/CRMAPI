import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-select-role',
  templateUrl: './select-role.component.html',
  styleUrls: ['./select-role.component.scss']
})
export class SelectRoleComponent{

  readonly array: Array<any>
  @Input() form!: FormGroup;
  constructor(fb: FormBuilder) {
    this.array = [
      { values: 1, viewValue: "Funcionario", disabled:true },
      { values: 2, viewValue: "Cliente", disabled:true },
      { values: 3, viewValue: "Gerente", disabled:true },
      { values: 4, viewValue: "Administrador", disabled:true }
    ];
  }
}