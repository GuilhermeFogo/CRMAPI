import { FormOpoComponent } from './../../Components/form-opo/form-opo.component';
import { Cliente } from './../../Modal/Cliente';
import { ClienteService } from './../../Services/HTTP/Cliente/cliente.service';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormClienteComponent } from 'src/app/Components/form-cliente/form-cliente.component';

@Component({
  selector: 'app-oportunidades',
  templateUrl: './oportunidades.component.html',
  styleUrls: ['./oportunidades.component.scss']
})
export class OportunidadesComponent implements OnInit {
  
  private dialog: MatDialog;
  private readonly ClienteService: ClienteService;
  private snackBar: MatSnackBar;
  constructor(dialog: MatDialog, _snackBar: MatSnackBar, clienteService: ClienteService) {
    this.dialog = dialog;
    this.snackBar = _snackBar;
    this.ClienteService = clienteService
  }
  ngOnInit(): void {
  }

  public AbrirModalCliente(){
    this.dialog.open(FormClienteComponent, {
      width: '250px',
      data: null
    }).afterClosed().subscribe(x => {
      if (x != undefined) {
        console.log(x);
        this.PostCliente(x);
      }
    });
  }

  
  public AbrirModalOPO(){
    this.dialog.open(FormOpoComponent, {
      width: '250px',
      data: null
    }).afterClosed().subscribe(x => {
      if (x != undefined) {
        console.log(x);
      }
    });
  }

  private PostCliente(cliente: Cliente){
    this.ClienteService.PostCliente(cliente).subscribe(x=>{
      this.snackBar.open("Cliente cadastrado com exito", "OK");
      console.log(x);
      
    }, error=>{
      this.snackBar.open("Aconteceu algum erro", "OK");
      console.log(error);
    })
  }
}
