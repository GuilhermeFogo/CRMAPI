import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-select-ativo',
  templateUrl: './select-ativo.component.html',
  styleUrls: ['./select-ativo.component.scss']
})
export class SelectAtivoComponent {

  readonly array: Array<any>
  @Input() form!: FormGroup;
  @Input() disabled_block!: boolean;
  constructor(fb: FormBuilder) {
    this.array = [
      { values: 1, viewValue: "Ativo", disabled: true },
      { values: 2, viewValue: "Desativado", disabled: true },
    ];
  }

}
