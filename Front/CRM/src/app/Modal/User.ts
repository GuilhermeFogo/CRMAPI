export class User {
    readonly id: number
    readonly nome: string;
    readonly senha: string;
    readonly role: number;
    readonly email: string;
    readonly ativado : boolean;

    public get Nome(): string {
        return this.nome;
    }

    public get Senha(): string {
        return this.senha;
    }

    public get Id(): number {
        return this.id;
    }

    public get Role(): number {
        return this.role;
    }

    public get Email() : string {
        return this.email;
    }

    
    public get Ativado() : boolean {
        return this.Ativado;
    }
    

    constructor({ nome, senha, id, role, email, ativado}: { nome: string, senha: string, id: number, role: number, email: string, ativado: boolean}) {
        this.nome = nome;
        this.senha = senha;
        this.id = id;
        this.role = role;
        this.email = email;
        this.ativado = ativado;
    }
}