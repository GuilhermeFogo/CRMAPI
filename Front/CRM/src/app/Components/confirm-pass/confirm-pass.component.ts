import { User } from 'src/app/Modal/User';
import { CookieService } from './../../Services/cookie/cookie.service';
import { ConfirmSenhaService } from './../../Services/HTTP/Resetsenha/confirmSenha.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-confirm-pass',
  templateUrl: './confirm-pass.component.html',
  styleUrls: ['./confirm-pass.component.scss']
})
export class ConfirmPassComponent implements OnInit {
  form!: FormGroup
  private fb: FormBuilder;
  private readonly confirmSenhaService: ConfirmSenhaService;
  private readonly CookieService: CookieService;
  private readonly _snackBar: MatSnackBar;
  constructor(fb: FormBuilder, ConfirmSenhaService: ConfirmSenhaService, CookieService: CookieService, 
    _snackBar: MatSnackBar) {
    this.fb = fb;
    this.confirmSenhaService = ConfirmSenhaService;
    this.CookieService = CookieService;
    this._snackBar = _snackBar;
  }


  public get f(): any {
    return this.form.controls;
  }


  ngOnInit(): void {
    this.form = this.fb.group({
      "codigo": ["", [Validators.required]]
    })
  }

  public OnSubmit() {
    const user = new User({
      ativado: false,
      codigoResgate: this.f.codigo.value,
      email: "",
      id: 0,
      nome: "",
      restsenha: false,
      role: 0,
      senha: ""
    })
    this.PostValida(user);
  }

  private PostValida(user: User) {
    this.confirmSenhaService.PostValida(user).subscribe({
      next: ()=>{
        let expires = this.CookieService.Expires(0,3,0);
        this.CookieService.CreateCookies("segredo",this.f.codigo.value,expires)
        this._snackBar.open("Codigo Validado com sucesso");
      },
      error:()=>{
        this._snackBar.open("Algo de errado aconteceu");
      }
    })
  }

}
