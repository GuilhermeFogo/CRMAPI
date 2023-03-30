import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Oportunidade } from 'src/app/Modal/Oportunidade';

@Component({
  selector: 'app-form-opo',
  templateUrl: './form-opo.component.html',
  styleUrls: ['./form-opo.component.scss']
})
export class FormOpoComponent implements OnInit {

  CreateEdit!: string
  form!: FormGroup;
  private fb: FormBuilder;
  private dialogRef: MatDialogRef<FormOpoComponent>;
  constructor(fb: FormBuilder, dialogRef: MatDialogRef<FormOpoComponent>, @Inject(MAT_DIALOG_DATA) public data: Oportunidade) {
    this.fb = fb;
    this.dialogRef = dialogRef;
    this.dialogRef.disableClose = true;
  }

  public get f(): any {
    return this.form.controls;
  }

  ngOnInit(): void {
    if (!this.data) {
      this.CreateEdit = "Criar";
      this.form = this.fb.group({
        responsavel: ["", [Validators.required]],
        aprovador:[""],
        id_opo: [""],
        id_produto: [""],
        nome_produto:[""],
        ativo_opo: [{ value: 1, disabled: false }],
        tipo_opo: [{ value: 1, disabled: false }],
        preco_produto: [0],
        tipo_produto: [{ value: 1, disabled: false }, Validators.required],
        data: [new Date(), Validators.required]
      })
    } else {
      this.CreateEdit = "Editar";
      this.form = this.fb.group({
        responsavel: [this.data.Responsavel, [Validators.required]],
        aprovador:[this.data.Aprovador,[Validators.required]],
        id_opo: [this.data.Id_oportunidade,],
        id_produto: [this.data.Id_produto],
        tipo_opo: [this.data.Tipo_oportunidade, [Validators.required]],
        nome_produto:[this.data.Nome_produto, [Validators.required]],
        ativo_opo: [{ value: this.TransformBool2Int(this.data.Ativo_Oportunidade) }, Validators.required],
        preco_produto: [this.data.Preco_produto],
        tipo_produto: [this.data.Categoria, Validators.required],
        data: [this.data.Data, Validators.required]
      })
    }
  }

  private TransformBool2Int(bool: boolean): number {
    if (bool) {
      return 1;
    } else {
      return 2;
    }
  }

  private TransformInt2Bool(num: number): boolean {
    if (num ==1) {
      return true;
    } else {
      return false;
    }
  }

  public Onsubmit() {
    console.log(this.MyObjetct());

  }


  public Close() {
    this.dialogRef.close();
  }

  private MyObjetct(){
    let campo_data :Date =this.f.data.value

    const obj = new Oportunidade({
      responsavel: this.f.responsavel.value,
      aprovador: this.f.aprovador.value,
      ativo_Oportunidade: this.TransformInt2Bool(this.f.ativo_opo.value),
      data: campo_data,
      id_oportunidade: "0",
      id_produto: "0",
      nome_produto: this.f.nome_produto.value,
      preco_produto: this.f.preco_produto.value,
      tipo_oportunidade: this.f.tipo_opo.value,
      categoria: this.f.tipo_produto.value,
      vinculado: false
    })
    return obj;
  }

}
