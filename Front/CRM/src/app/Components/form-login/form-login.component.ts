import { UsuariosServiceService } from './../../Services/HTTP/Usuarios/usuarios-service.service';
import { AuthService } from './../../Services/HTTP/Auth/auth.service';
import { CookieService } from './../../Services/cookie/cookie.service';
import {FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import {User} from '../../Modal/User';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-form-login',
  templateUrl: './form-login.component.html',
  styleUrls: ['./form-login.component.scss']
})
export class FormLoginComponent implements OnInit {
 
  private fb: FormBuilder;
  form!: FormGroup;
  private route: Router;
  private cookie: CookieService;
  private Auth: AuthService;
  private _snackBar: MatSnackBar
  
  constructor(fb: FormBuilder, route: Router, CookieService: CookieService, Auth: AuthService, snackBar: MatSnackBar) {
    this.fb = fb;
    this.route = route;
    this.cookie = CookieService
    this.Auth = Auth;
    this._snackBar = snackBar;
  }

  
  public get f(): any{
    return this.form.controls;
  }
  

  ngOnInit(): void {
    this.form = this.fb.group({
      nameUser:["", Validators.required],
      pass: ["", Validators.required]
    });
  }

  public OnSubmit() {
    const user = new User({
      id: 0,
      nome: this.f.nameUser.value,
      senha: this.f.pass.value,
      role: 0,
      email: "",
      ativado : false,
      restsenha: false
    });
    const expires =  this.cookie.Expires(0,0,2);
    
    this.Auth.Autenticar(user).subscribe(x=>{
      if(x!=null){
        this.cookie.CreateCookie(x, expires);
        this.route.navigateByUrl("/DashBoard");
      }else{
        this.route.navigateByUrl("/");
        this._snackBar.open("Usuário não existe / Desativado ou senha invalida","OK")
      }
    },e => this._snackBar.open("Tente Novamente","OK"));
  }

  public ResetSenha(){
    this.route.navigateByUrl("/resetSenha");
  }
}
