import { OportunidadesService } from './../../Services/HTTP/Oportunidades/oportunidades.service';
import { FormOpoComponent } from './../../Components/form-opo/form-opo.component';
import { Cliente } from './../../Modal/Cliente';
import { ClienteService } from './../../Services/HTTP/Cliente/cliente.service';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormClienteComponent } from 'src/app/Components/form-cliente/form-cliente.component';
import { Oportunidade } from 'src/app/Modal/Oportunidade';

@Component({
  selector: 'app-oportunidades',
  templateUrl: './oportunidades.component.html',
  styleUrls: ['./oportunidades.component.scss']
})
export class OportunidadesComponent implements OnInit {

  private dialog: MatDialog;
  private readonly ClienteService: ClienteService;
  private readonly OportunidadesService: OportunidadesService;
  private snackBar: MatSnackBar;
  constructor(dialog: MatDialog, _snackBar: MatSnackBar, clienteService: ClienteService, oportunidadesService: OportunidadesService) {
    this.dialog = dialog;
    this.snackBar = _snackBar;
    this.ClienteService = clienteService;
    this.OportunidadesService = oportunidadesService;
  }
  ngOnInit(): void {
  }

  public AbrirModalCliente() {
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


  public AbrirModalOPO() {
    this.dialog.open(FormOpoComponent, {
      width: '250px',
      data: null
    }).afterClosed().subscribe(x => {
      if (x != undefined) {
        this.PostOportunidade(x);
      }
    });
  }

  private PostCliente(cliente: Cliente) {
    this.ClienteService.PostCliente(cliente).subscribe(x => {
      this.snackBar.open("Cliente cadastrado com exito", "OK");
      console.log(x);

    }, error => {
      this.snackBar.open("Aconteceu algum erro", "OK");
      console.log(error);
    })
  }

  private PostOportunidade(oportunidade: Oportunidade) {
    this.OportunidadesService.PostOportunidade(oportunidade).subscribe({
      next: () => {
        this.snackBar.open("Oportunidade Criada","OK")
      },
      error: (erro) => {
        this.snackBar.open("Erro na criação da Oportunidade","OK")
        console.log(erro)
      }
    })
  }

}
