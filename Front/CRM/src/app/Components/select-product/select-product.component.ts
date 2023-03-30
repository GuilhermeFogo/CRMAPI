import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, Input} from '@angular/core';

@Component({
  selector: 'app-select-product',
  templateUrl: './select-product.component.html',
  styleUrls: ['./select-product.component.scss']
})
export class SelectProductComponent{
  readonly array: Array<any>
  @Input() form!: FormGroup;
  @Input() disabled_block!: boolean;
  @Input() FormControlName_!: string
  constructor(fb: FormBuilder) {
    this.array = [
      { values: 1, viewValue: "Serviços - Gerais", disabled: true },
      { values: 2, viewValue: "Serviços- Financeiro", disabled: true },
      { values: 3, viewValue: "Serviços- Contabil", disabled: true },
      { values: 4, viewValue: "Serviços- Administrativo", disabled: true },
      { values: 5, viewValue: "Serviços- Juridico", disabled: true },
      { values: 6, viewValue: "Serviços- Tercerizado", disabled: true }
    ];
  }
}