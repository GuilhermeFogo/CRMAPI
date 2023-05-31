export class Oportunidade {

    private responsavel: string
    private id_oportunidade: string
    private status_oportunidade: string

    private ativo_Oportunidade: boolean
    private CNPJ: string
    private CPF:string
    private id_produto: string
    private nome_produto: string
    private preco_produto: string
    private categoria: string
    private data: Date
    private aprovador: string
    private vinculado: boolean


    constructor({ responsavel, id_oportunidade, status_oportunidade, ativo_Oportunidade, id_produto, nome_produto, preco_produto, categoria, data, aprovador, vinculado, CPF,CNPJ }: {
            responsavel: string, id_oportunidade: string, status_oportunidade: string, ativo_Oportunidade: boolean, id_produto: string, nome_produto: string, 
            preco_produto: string, categoria: string, data: Date, aprovador: string, vinculado:boolean, CNPJ: string, CPF:string
        }
    ) {
        this.aprovador = aprovador;
        this.ativo_Oportunidade = ativo_Oportunidade;
        this.data = data;
        this.id_oportunidade = id_oportunidade;
        this.id_produto = id_produto;
        this.nome_produto = nome_produto;
        this.preco_produto = preco_produto;
        this.responsavel = responsavel;
        this.categoria = categoria;
        this.status_oportunidade = status_oportunidade;
        this.vinculado =vinculado;
        this.CNPJ = CNPJ;
        this.CPF = CPF;
    }

    public get Aprovador(): string {
        return this.aprovador;
    }

    public get Ativo_Oportunidade(): boolean {
        return this.ativo_Oportunidade;
    }

    public get Data(): Date {
        return this.data;
    }
    public get Categoria(): string {
        return this.categoria;
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

    public get Status_oportunidade(): string {
        return this.status_oportunidade;
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
    
    
    public get CNPJs() : string {
        return this.CNPJ;
    }
    
    public get CPFs() : string {
        return this.CPF;
    }
    
    

}