export class User {
    readonly id: number
    readonly nome: string;
    readonly senha: string;
    readonly role: number;
    readonly email: string;
    readonly ativado : boolean;
    readonly resetsenha: boolean;
    readonly codigoResgate: string;

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
    
    
    public get ResetSenha() : boolean {
        return this.resetsenha;
    }

    public get CodigoResgate() : string {
        return this.codigoResgate;
    }
 
    constructor({ nome, senha, id, role, email, ativado,restsenha, codigoResgate}:
         { nome: string, senha: string, id: number, role: number, email: string, 
            ativado: boolean, restsenha:boolean, codigoResgate:string}) {
        this.nome = nome;
        this.senha = senha;
        this.id = id;
        this.role = role;
        this.email = email;
        this.ativado = ativado;
        this.resetsenha =restsenha;
        this.codigoResgate = codigoResgate;
    }
}