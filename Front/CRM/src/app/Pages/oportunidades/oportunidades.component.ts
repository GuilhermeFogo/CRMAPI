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
  
  private snackBar: MatSnackBar;
  constructor(dialog: MatDialog,  _snackBar: MatSnackBar) {
    this.dialog = dialog;
    this.snackBar = _snackBar;
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
      }
    });
  }

  
  public AbrirModalProduto(){
    
  }
}
