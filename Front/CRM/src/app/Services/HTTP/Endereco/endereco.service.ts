import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EnderecoService {
  private http:HttpClient
  private url:string;
  constructor(http:HttpClient) { 
    this.http = http;
    this.url = "https://viacep.com.br/ws/"
  }

  public getCEP(cep: string){
    return this.http.get(this.url +cep +'/json');
  }
  
}
