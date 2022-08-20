import { UsuariosServiceService } from './../../Services/HTTP/Usuarios/usuarios-service.service';
import { User } from 'src/app/Modal/User';
import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit } from '@angular/core';
import { FormUserComponent } from 'src/app/Components/form-user/form-user.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
@Component({
  selector: 'app-gerencia-user',
  templateUrl: './gerencia-user.component.html',
  styleUrls: ['./gerencia-user.component.scss']
})
export class GerenciaUserComponent implements OnInit {

  private dialog: MatDialog;
  private request: UsuariosServiceService;
  displayedColumns: string[] = ['nome', 'role', 'email', 'ativo', 'Edit'];
  dataSource!: MatTableDataSource<User>;
  private snackBar: MatSnackBar;
  constructor(dialog: MatDialog, request: UsuariosServiceService, _snackBar: MatSnackBar) {
    this.dialog = dialog;
    this.request = request;
    this.snackBar = _snackBar;
  }

  ngOnInit(): void {
    this.Lista();
  }

  public Criaruser() {
    this.dialog.open(FormUserComponent, {
      width: '250px',
      data: null
    }).afterClosed().subscribe(x => {
      if (x != undefined) {
        this.postUser(x);
      }
    });
  }


  public Atualizar(user: User) {
    this.dialog.open(FormUserComponent, {
      width: '250px',
      data: user
    }).afterClosed().subscribe(x => {
      if (x != undefined) {
        this.putUser(x);
      }
      this.ngOnInit();
    });
  }

  public Deletar(user: User) {
    this.deleteUser(user);
    this.ngOnInit();
  }




  public Lista() {
    this.request.ListaUser().subscribe(usarios => {

      this.dataSource = new MatTableDataSource(usarios);
      console.log(usarios);

    },
      erro => console.error(erro))
  }

  private postUser(user: User) {
    this.request.SaveUser(user).subscribe(x => {
      this.snackBar.open("Cadastrado com Exito", "OK");
    }, e => {
      this.snackBar.open(e.error.text, "OK");
    })
  }

  private putUser(user: User) {
    this.request.UpdateUser(user).subscribe(x => {
      this.snackBar.open("Atualizado com exito", "OK");
    }, error => {
      this.snackBar.open(error.error.text, "OK");
    });
  }

  private deleteUser(user: User) {
    this.request.Delete(user.id).subscribe(x => {
      this.snackBar.open("Usuario deletado com exito", "OK")
    }, error => {
      this.snackBar.open(error.error.text, "OK");
    });
  }

}