import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormClienteComponent } from 'src/app/Components/form-cliente/form-cliente.component';
import { Cliente } from 'src/app/Modal/Cliente';
import { ClienteService } from 'src/app/Services/HTTP/Cliente/cliente.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.scss']
})
export class ClientesComponent implements OnInit {

  private dialog: MatDialog;
  private readonly ClienteService: ClienteService;
  private snackBar: MatSnackBar;
  public DadosTabela: Cliente[]
  constructor(dialog: MatDialog, _snackBar: MatSnackBar, clienteService: ClienteService) {
    this.dialog = dialog;
    this.snackBar = _snackBar;
    this.ClienteService = clienteService
    this.DadosTabela =[]
  }

  ngOnInit(): void {
    this.GetCliente()
  }


  public AbrirModalCliente(){
    this.dialog.open(FormClienteComponent, {
      width: '250px',
      data: null
    }).afterClosed().subscribe(x => {
      if (x != undefined) {
        console.log(x) ;
        this.PostCliente(x);
        
      }
    });
  }


  public EditarCliente(cliente:Cliente){
    this.dialog.open(FormClienteComponent, {
      width: '250px',
      data: cliente
    }).afterClosed().subscribe(x => {
      if (x != undefined) {
        this.PutCliente(x);
      }
    });
  }

  /**
   * name
   */
  public Delete(cliente:Cliente) {
    this.DeleteCliente(cliente);
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

  private GetCliente(){
    this.ClienteService.VerClientes().subscribe(x=>{
      console.log(x);
      this.DadosTabela =x
    });
  }

  private PutCliente(cliente: Cliente) {
    this.ClienteService.PutCliente(cliente).subscribe(x=>{
      this.snackBar.open("Cliente "+ cliente.nome+" Editado com exito","OK")
    }, error=>{
      console.log(error);
      
    })
  }


  private DeleteCliente(cliente: Cliente) {
    this.ClienteService.DeleteCliente(cliente).subscribe(x=>{
      this.snackBar.open("Cliente "+ cliente.nome+" Deletado com exito","OK")
    }, error=>{
      console.log(error);
      
    })
  }
}
