import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-select-opo',
  templateUrl: './select-opo.component.html',
  styleUrls: ['./select-opo.component.scss']
})
export class SelectOpoComponent {

  readonly array: Array<any>
  @Input() form!: FormGroup;
  @Input() disabled_block!: boolean;
  @Input() FormControlName_!: string
  
  constructor(fb: FormBuilder) {
    this.array = [
      { values: 1, viewValue: "Aberta", disabled: true },
      { values: 2, viewValue: "Prospeção", disabled: true },
      { values: 3, viewValue: "Concluido", disabled: true },
      { values: 4, viewValue: "Perdido", disabled: true }
    ];
  }
}
