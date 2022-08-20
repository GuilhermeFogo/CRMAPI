import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  
  public configMenu: IMenu[] = [];
  
  private readonly rotas: Router;
  constructor(rotas: Router){
    this.rotas = rotas;

  }

  ngOnInit(): void {
    this.configMenu =[
      {
        titulo: "Home",
        rota: "/DashBoard",
        display: false
      },
      {
        titulo:"Datamapping",
        rota: "/DataMapping",
        display: false
      }, 
      {
        titulo: "Usuarios",
        rota:"/Users",
        display:false
      }
    ]
  }

  public Click(link: string){
    this.rotas.navigateByUrl(link);
  }
}

interface IMenu{
  titulo:string,
  rota: string,
  display: boolean
}