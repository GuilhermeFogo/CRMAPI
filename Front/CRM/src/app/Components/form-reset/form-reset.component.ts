import { CookieService } from './../../Services/cookie/cookie.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/Modal/User';
import { ResetsenhaService } from 'src/app/Services/HTTP/Resetsenha/resetsenha.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-form-reset',
  templateUrl: './form-reset.component.html',
  styleUrls: ['./form-reset.component.scss']
})
export class FormResetComponent implements OnInit {

  form!: FormGroup;
  private fb: FormBuilder;
  private readonly ResetsenhaService: ResetsenhaService;
  private readonly _snackBar: MatSnackBar;
  private readonly CookieService: CookieService;

  constructor(fb: FormBuilder, ResetsenhaService: ResetsenhaService, _snackBar: MatSnackBar, CookieService: CookieService) {
    this.fb = fb;
    this.ResetsenhaService = ResetsenhaService
    this._snackBar = _snackBar;
    this.CookieService = CookieService;
  }

  ngOnInit(): void {

    this.form = this.fb.group({
      "email": ["", [Validators.email, Validators.required]]
    });
  }

  public get f(): any {
    return this.form.controls;
  }

  public OnSubmit() {
    const user = new User({
      id: 0,
      nome: "",
      senha: "",
      role: 0,
      email: this.f.email.value,
      ativado: false,
      restsenha: false,
      codigoResgate:""
    });

    this.PostResetsenha(user);
  }

  private PostResetsenha(user: User): any {
    this.ResetsenhaService.PostEmail(user).subscribe({
      next: () => {
        let expiress = this.CookieService.Expires(0,10,0);
        let campo =  this.f.email.value;
        this.CookieService.CreateCookies("reset",campo,expiress);
        this._snackBar.open("Verifique sua caixa no e-mail", "OK");
      },
      error: () => {
        this._snackBar.open("E-mail invalido ou não existe", "OK")
      }
    })
  }
}

