import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-confirm-pass',
  templateUrl: './confirm-pass.component.html',
  styleUrls: ['./confirm-pass.component.scss']
})
export class ConfirmPassComponent implements OnInit {
  form!: FormGroup
  private fb: FormBuilder;
  constructor(fb: FormBuilder) {
    this.fb = fb;
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      "codigo":["",[Validators.required]]
    })
  }

  OnSubmit(){

  }

}
