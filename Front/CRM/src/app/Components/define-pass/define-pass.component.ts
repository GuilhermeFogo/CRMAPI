import { CookieService } from './../../Services/cookie/cookie.service';
import { ResetsenhaService } from './../../Services/HTTP/Resetsenha/resetsenha.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { User } from 'src/app/Modal/User';

@Component({
  selector: 'app-define-pass',
  templateUrl: './define-pass.component.html',
  styleUrls: ['./define-pass.component.scss']
})
export class DefinePassComponent implements OnInit {
  hide = true
  hide2 = true
  form!: FormGroup
  private readonly fb: FormBuilder;
  private readonly _snackBar: MatSnackBar;
  private readonly CookieService:CookieService;
  private ResetsenhaService: ResetsenhaService

  constructor(fb: FormBuilder, _snackBar: MatSnackBar, ResetsenhaService: ResetsenhaService,
    CookieService:CookieService) {
    this.fb = fb;
    this._snackBar =_snackBar;
    this.ResetsenhaService =ResetsenhaService;
    this.CookieService = CookieService;
  }


  public get f(): any {
    return this.form.controls;
  }


  ngOnInit(): void {
    this.form = this.fb.group({
      "senha": ["", [Validators.required, Validators.min(8)]],
      "confirmSenha": ["", [Validators.required, Validators.min(8)]]
    })
  }

  OnSubmit() {
    if (this.CamposIguais()) {
      const user = new User({
        id: 0,
        nome: "",
        senha: this.f.senha.value,
        role: 0,
        email: this.PegaCookie(),
        ativado: false,
        restsenha: false
      });

      this.PostResetsenha(user);
    }else{
      this._snackBar.open("Campos de senha diferentes")
    }
  }

  private CamposIguais(): boolean {
    let pass = this.f.senha.value;
    let confirm = this.f.confirmSenha.value;
    if (pass === confirm) {
      return true;
    } else {
      return false;
    }
  }

  private PegaCookie(){
    return this.CookieService.getValueCookie("reset");
  }

  private PostResetsenha(user: User): any {
    this.ResetsenhaService.PostEmail(user).subscribe({
      next: () => {
        this._snackBar.open("Troca de Senha efetuada com exito", "OK");
      },
      error: () => {
        this._snackBar.open("Aconteu algum erro, tente novamente", "OK")
      }
    })
  }

}
