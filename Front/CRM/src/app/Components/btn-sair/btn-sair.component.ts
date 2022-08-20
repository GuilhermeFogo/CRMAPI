import { CookieService } from './../../Services/cookie/cookie.service';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-btn-sair',
  templateUrl: './btn-sair.component.html',
  styleUrls: ['./btn-sair.component.scss']
})
export class BtnSairComponent implements OnInit {

  private rotas: Router;
  private cookie: CookieService;
  constructor(rotas: Router, cookie: CookieService){
    this.rotas = rotas;
    this.cookie = cookie;
    
  }


  public ClickSair(){
    this.cookie.DeleteCookie("Session");
    this.rotas.navigateByUrl('');
  }

  ngOnInit(): void {
  }

}
