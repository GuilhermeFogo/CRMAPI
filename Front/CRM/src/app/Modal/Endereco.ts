export class Endereco {
    readonly cep;
    readonly rua;
    readonly id_Endereco;
    readonly complemento;
    readonly cidade;
    readonly estado;
    readonly bairro;

    
    public get Bairro() : string {
        return this.bairro;
    }
    

    public get CEP() : string {
        return this.cep;
    }
    
    
    public get Estado() : string {
        return this.estado;
    }
    
    
    public get Cidade() : string {
        return this.cidade;
    }
    
    public get IdEndereco() : string {
        return this.id_Endereco
    }

    public get Rua() : string {
        return this.rua;
    }
    
    
    public get Complemento() : string {
        return this.complemento;
    }
    
    
    

    constructor({ idEndereco, cep, rua, complemento, cidade, estado, bairro }:
        { idEndereco: string, cep: string, rua: string, complemento: string, 
        cidade: string, estado: string, bairro: string }) {
        this.cep = cep;
        this.cidade = cidade;
        this.complemento = complemento;
        this.estado = estado;
        this.id_Endereco = idEndereco;
        this.rua = rua;
        this.bairro = bairro;
    }
}