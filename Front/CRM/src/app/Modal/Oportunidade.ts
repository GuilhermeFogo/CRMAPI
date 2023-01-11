class Oportunidade {

    private responsavel: string
    private id_oportunidade: string
    private tipo_oportunidade: string

    private ativo_Oportunidade: boolean

    private id_produto: string
    private nome_produto: string
    private preco_produto: string
    private tipo_Produto: string

    private id_cliente: string
    private consentimento: boolean
    private ativo_cliente: string

    private nome_cliente: string
    private email_cliente: string
    private telefone_cliente: string
    private cpf_cliente: string
    private cnpj_cliente: string
    private data: Date
    private aprovador: string
    private vinculado: boolean


    constructor({ responsavel, id_oportunidade, tipo_oportunidade, ativo_Oportunidade, id_produto, nome_produto, preco_produto, tipo_Produto, id_cliente, consentimento,
        ativo_cliente, nome_cliente, email_cliente, telefone_cliente, cpf_cliente, cnpj_cliente, data, aprovador, vinculado }: {
            responsavel: string, id_oportunidade: string, tipo_oportunidade: string, ativo_Oportunidade: boolean, id_produto: string, nome_produto: string, preco_produto: string, tipo_Produto: string, id_cliente: string,
            consentimento: boolean, ativo_cliente: string, nome_cliente: string, email_cliente: string, telefone_cliente: string, cpf_cliente: string, cnpj_cliente: string,
            data: Date, aprovador: string, vinculado:boolean
        }
    ) {
        this.aprovador = aprovador;
        this.ativo_Oportunidade = ativo_Oportunidade;
        this.ativo_cliente = ativo_cliente;
        this.cnpj_cliente = cnpj_cliente;
        this.consentimento = consentimento;
        this.cpf_cliente = cpf_cliente;
        this.data = data;
        this.email_cliente = email_cliente;
        this.id_cliente = id_cliente;
        this.id_oportunidade = id_oportunidade;
        this.id_produto = id_produto;
        this.nome_cliente = nome_cliente;
        this.nome_produto = nome_produto;
        this.preco_produto = preco_produto;
        this.responsavel = responsavel;
        this.telefone_cliente = telefone_cliente;
        this.tipo_Produto = tipo_Produto;
        this.tipo_oportunidade = tipo_oportunidade;
        this.vinculado =vinculado
    }

    public get Aprovador(): string {
        return this.aprovador;
    }

    public get Ativo_Oportunidade(): boolean {
        return this.ativo_Oportunidade;
    }

    public get Ativo_Cliente(): string {
        return this.ativo_cliente
    }

    public get CNPJ_Cliente(): string {
        return this.cnpj_cliente;
    }

    public get CPF_Cliente(): string {
        return this.cpf_cliente
    }

    public get Telefone_Cliente(): string {
        return this.telefone_cliente
    }

    public get Data(): Date {
        return this.data;
    }

    public get Email_Cliente(): string {
        return this.email_cliente;
    }


    public get Nome_Cliente(): string {
        return this.nome_cliente;
    }

    public get Consentimento(): boolean {
        return this.consentimento
    }

    public get Id_cliente(): string {
        return this.id_cliente;
    }

    public get Tipo_produto(): string {
        return this.tipo_Produto;
    }

    public get Preco_produto(): string {
        return this.preco_produto;
    }

    public get Nome_produto(): string {
        return this.nome_produto;
    }

    public get Id_produto(): string {
        return this.id_produto;
    }

    public get Tipo_oportunidade(): string {
        return this.tipo_oportunidade;
    }

    public get Id_oportunidade(): string {
        return this.id_oportunidade;
    }

    public get Responsavel(): string {
        return this.responsavel;
    }
    
    public get Vinculado() : boolean {
        return this.vinculado
    }
    

}