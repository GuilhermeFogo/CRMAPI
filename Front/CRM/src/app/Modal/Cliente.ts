import { Endereco } from "./Endereco";

export class Cliente {
    public readonly Nome: string;
    public readonly Email: string;
    public readonly Id_Cliente: string;
    public readonly Telefone: string;
    public readonly endereco: Endereco;
    public readonly CPF: string;
    public readonly CNPJ:string;

    constructor({ id_Cliente, nome, telefone, email, 
        idEndereco, cep, complemento, estado, cidade, rua, bairro, cnpj, cpf }: 
        { id_Cliente: string, nome: string, telefone: string, email: string , 
            idEndereco: string, cep: string, cidade: string, complemento:string, 
            estado: string, rua: string, bairro: string, cnpj:string, cpf:string}) {
            this.Email = email;
            this.Id_Cliente = id_Cliente;
            this.Nome = nome;
            this.Telefone = telefone;
            this.endereco = new Endereco({
                idEndereco: idEndereco,
                cep:  cep,
                cidade: cidade,
                complemento: complemento,
                estado: estado,
                rua: rua,
                bairro: bairro
            })
            this.CNPJ = cnpj;
            this.CPF = cpf;
    }
    
}