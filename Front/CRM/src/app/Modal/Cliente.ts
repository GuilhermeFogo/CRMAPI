class Cliente {
    public readonly Nome: string;
    public readonly Email: string;
    public readonly Id_Cliente: string;
    public readonly Telefone: string;
    public readonly Rua: string;
    public readonly CEP: string;
    public readonly Complemento: string;
    public readonly Consentimento: string;
    public readonly Bairro: string;
    public readonly Id_Endereço:string;

    constructor({nome, email, tel, id_cliente, rua, cep, complemento, bairro, consentimento, id_endereco}:{
        nome: string, email:string, tel:string, id_cliente:string, rua:string, cep:string, complemento: string, bairro:string, consentimento:string, id_endereco:string
    }) {
        this.Nome = nome;
        this.Bairro = bairro;
        this.CEP = cep,
        this.Complemento = complemento,
        this.Consentimento = consentimento;
        this.Email = email;
        this.Id_Cliente = id_cliente;
        this.Id_Endereço = id_endereco;
        this.Rua = rua;
        this.Telefone = tel;
    }
    
}