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
  private readonly rota: Router;
  private _snackBar: MatSnackBar;
  
  constructor(fb: FormBuilder, ResetsenhaService: ResetsenhaService, rota: Router, _snackBar: MatSnackBar) {
    this.fb = fb;
    this.ResetsenhaService = ResetsenhaService
    this.rota = rota;
    this._snackBar =_snackBar;
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      "email": ["", [Validators.email, Validators.required]]
    })
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
      ativado: false
    });

    this.PostResetsenha(user);
  }

  private PostResetsenha(user: User): any {
    this.ResetsenhaService.PostEmail(user).subscribe({
      next: () => {
        this._snackBar.open("Verifique sua caixa no e-mail","OK");
        this.rota.navigateByUrl("");
      },
      error: () => {
        this._snackBar.open("E-mail invalido ou não existe","OK")    
      }
    })
  }
}

