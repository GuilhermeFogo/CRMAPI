import { Endereco } from "./Endereco";

export class Cliente {
    public readonly Nome: string;
    public readonly Email: string;
    public readonly Id: string;
    public readonly Telefone: string;
    //public readonly endereco: Endereco;
    public readonly CPF: string;
    public readonly CNPJ:string;
    public readonly Ativo: boolean;
    public readonly Consentimento: boolean;
    public readonly cep: string;
    public readonly rua: string;
    public readonly id_Endereco: string;
    public readonly complemento: string;
    public readonly cidade: string;
    public readonly estado: string;
    public readonly bairro: string;

    constructor({ id_Cliente, nome, telefone, email, 
        idEndereco, cep, complemento, estado, cidade, rua, bairro, cnpj, cpf, ativo, consentimento}: 
        { id_Cliente: string, nome: string, telefone: string, email: string , 
            idEndereco: string, cep: string, cidade: string, complemento:string, 
            estado: string, rua: string, bairro: string, cnpj:string, cpf:string, ativo: boolean, consentimento: boolean}) {
            this.Email = email;
            this.Id = id_Cliente;
            this.Nome = nome;
            this.Telefone = telefone;
            this.id_Endereco = idEndereco;
            this.cep=  cep;
            this.cidade= cidade;
            this.complemento= complemento;
            this.estado= estado;
            this.rua= rua;
            this.bairro= bairro;
            this.CNPJ = cnpj;
            this.CPF = cpf;
            this.Ativo = ativo;
            this.Consentimento = consentimento
    }
    
    public get nome(): string{
        return this.Nome;
    }
    public get email():string{
        return this.email;
    }

    public get telefone():string{
        return this.telefone
    }
    public get cnpj(): string{
        return this.CNPJ
    }

    public get cpf(): string{
        return this.cpf
    }

    public get ativo():boolean{
        return this.ativo
    }
    public get consentimento(): boolean{
        return this.consentimento
    }
    public get id():string{
        return this.id;
    }

    public get id_endereco():string{
        return this.id_Endereco;
    }

    public get Rua():string{
        return this.rua;
    }

    public get Cep():string{
        return this.cep;
    }
    public get Bairro():string{
        return this.bairro;
    }

    public get Estado():string{
        return this.estado;
    }
    public get Complemento():string{
        return this.complemento;
    }
    public get Cidade():string{
        return this.cidade;
    }
}