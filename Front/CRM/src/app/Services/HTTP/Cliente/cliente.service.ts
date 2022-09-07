import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Cliente } from 'src/app/Modal/Cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  private readonly http: HttpClient;
  private readonly url: string;
  constructor(http: HttpClient) {
    this.http = http;
    this.url = environment.Local + "api/Cliente/";
  }

  public VerClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.url);
  }

  public PostCliente(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(this.url, cliente);
  }

  public PutCliente(cliente: Cliente): Observable<Cliente> {
    return this.http.put<Cliente>(this.url, cliente);
  }

  public DeleteCliente(cliente:Cliente): Observable<Cliente> {
    return this.http.delete<Cliente>(this.url+ cliente.Id_Cliente);
  }

}
