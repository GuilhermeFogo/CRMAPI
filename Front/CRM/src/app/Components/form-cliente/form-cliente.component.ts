import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Cliente } from 'src/app/Modal/Cliente';
import { EnderecoService } from 'src/app/Services/HTTP/Endereco/endereco.service';


@Component({
  selector: 'app-form-cliente',
  templateUrl: './form-cliente.component.html',
  styleUrls: ['./form-cliente.component.scss']
})
export class FormClienteComponent implements OnInit {

  form!: FormGroup;
  CreateEdit!: string;
  private enderecoService: EnderecoService
  private fb: FormBuilder;
  private dialogRef: MatDialogRef<FormClienteComponent>;
  constructor(fb: FormBuilder, enderecoService: EnderecoService, @Inject(MAT_DIALOG_DATA) public data: Cliente, dialogRef: MatDialogRef<FormClienteComponent>) {
    this.fb = fb;
    this.dialogRef = dialogRef;
    this.enderecoService = enderecoService
    this.dialogRef.disableClose = true;
  }


  public get f(): any {
    return this.form.controls;
  }

  ngOnInit(): void {
    if (!this.data) {
      this.CreateEdit = "Criando";
      this.form = this.fb.group({
        nome: ['', [Validators.required]],
        telefone: ['', [Validators.required]],
        id: [''],
        email: ['', [Validators.required, Validators.email]],
        rua: ['',[Validators.required]],
        cep: ['', [Validators.required, Validators.maxLength(9)]],
        cidade: ['', Validators.required],
        estado:['', Validators.required],
        complemento:[''],
        bairro:['', Validators.required],
        id_Endereco:['', Validators.required],
        cnpj:['',[Validators.required]],
        cpf:['', Validators.required],
        ativo:[{value: 1, disabled:true}],
        consentimento:[{value: 1, disabled:true}]
      })
    } else {
      this.CreateEdit = "Editando";
      this.form = this.fb.group({
        nome: [this.data.nome, [Validators.required]],
        telefone: [this.data.telefone, [Validators.required]],
        id: [this.data.id],
        email: [this.data.email, [Validators.required, Validators.email]],
        rua: [this.data.rua,[Validators.required]],
        cep: [this.data.cep, [Validators.required, Validators.maxLength(9)]],
        cidade: [this.data.cidade, Validators.required],
        estado:[this.data.estado, Validators.required],
        bairro:[this.data.bairro, Validators.required],
        complemento:[this.data.complemento],
        id_Endereco:[this.data.id_Endereco, Validators.required],
        cnpj:[this.data.cnpj, Validators.required],
        cpf:[this.data.cpf, Validators.required],
        ativo:[{value: this.transformAtivado(this.data.ativo), disabled:false}, Validators.required],
        consentimento:[{value: this.transformAtivado(this.data.consentimento), disabled:false}, Validators.required]
      })
    }
  }


  private CamposPreenchido(id: string, objeto: any) {
    this.f.estado.setValue(objeto.uf);
    this.f.cidade.setValue(objeto.localidade);
    this.f.rua.setValue(objeto.logradouro);
    this.f.cep.setValue(objeto.cep);
    this.f.complemento.setValue(objeto.complemento);
    this.f.bairro.setValue(objeto.bairro);
    this.f.id_Endereco.setValue(id);
  }

  private transformAtivado(ativado: boolean): number {
    if (ativado === true) {
      return 1;
    }
    return 2;
  }


  private transformAtivado2(ativado: number): boolean {
    if(ativado === 1){
      return true;
    }else{
      return false;
    }
  }



  public searchCEP(){
    this.getCEP(this.f.cep.value)
  }
  private getCEP(cepvalue: string) {
      this.enderecoService.getCEP(cepvalue).subscribe(x => {
        if (!this.data) {
           this.CamposPreenchido("0", x)
        } else {
          this.CamposPreenchido(this.data.id_Endereco, x)
        }
  
      }, error => { console.log(error) })
    }


  public Onsubmit() {
    this.dialogRef.close(this.MyClient());
  }

  public Close() {
    this.dialogRef.close(undefined);
  }


  public ValidaCampoCNPJ(){

    if(this.form.get("cnpj")?.value !="" &&this.form.get("cnpj")?.value !=0){
      this.form.get("cpf")?.setValue("0");
    }
  } 

  public ValidaCampoCPF(){
    if(this.form.get("cpf")?.value !="" && this.form.get("cpf")?.value !=0){
      this.form.get("cnpj")?.setValue("0");
    }
  }

  private MyClient(): Cliente {
    if (!this.data) {
      const newCliente = new Cliente({
        nome: this.f.nome.value,
        id_Cliente: "0",
        telefone : this.f.telefone.value,
        email: this.f.email.value,
        cep: this.f.cep.value,
        cidade:this.f.cidade.value,
        complemento:this.f.complemento.value,
        estado: this.f.estado.value,
        idEndereco:"0",
        rua: this.f.rua.value,
        bairro: this.f.bairro.value,
        cnpj :this.f.cnpj.value.toString(),
        cpf: this.f.cpf.value.toString(),
        ativo: true,
        consentimento: true
      })
      return newCliente;
    } else {
      const editCliente = new Cliente({
        nome: this.f.nome.value,
        id_Cliente: this.f.id.value,
        telefone : this.f.telefone.value,
        email: this.f.email.value,
        cep: this.f.cep.value,
        cidade:this.f.cidade.value,
        complemento:this.f.complemento.value,
        estado: this.f.estado.value,
        idEndereco: this.f.id_Endereco.value,
        rua: this.f.rua.value,
        bairro: this.f.bairro.value,
        cnpj :this.f.cnpj.value.toString(),
        cpf: this.f.cpf.value.toString(),
        ativo: this.transformAtivado2(this.f.ativo.value),
        consentimento: this.transformAtivado2(this.f.consentimento.value)
      })
      return editCliente;
    }
  }

}
