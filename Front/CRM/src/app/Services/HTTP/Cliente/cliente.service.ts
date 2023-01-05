import { CookieService } from './../../cookie/cookie.service';
import { HelperRequests } from 'src/app/Helper/helper-requests';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Cliente } from 'src/app/Modal/Cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService extends HelperRequests {
  private readonly http: HttpClient;
  private readonly url: string;
  constructor(http: HttpClient, cookie: CookieService) {
    super(cookie)
    this.http = http;
    this.url = environment.Local + "/api/Cliente";
  }

  public VerClientes(): Observable<Cliente[]> {
    const header = this.Ajudarequest();
    return this.http.get<Cliente[]>(this.url,{
      headers: header
    });
  }

  public PostCliente(cliente: Cliente): Observable<Cliente> {
    const header = this.Ajudarequest();
    return this.http.post<Cliente>(this.url, cliente,{
      headers: header
    });
  }

  public PutCliente(cliente: Cliente): Observable<Cliente> {
    const header = this.Ajudarequest();
    return this.http.put<Cliente>(this.url+"/"+ cliente.Id, cliente,{
      headers:header
    });
  }

  public DeleteCliente(cliente:Cliente): Observable<Cliente> {
    const header = this.Ajudarequest();
    return this.http.delete<Cliente>(this.url+"/"+ cliente.Id,{
      headers: header
    });
  }

}
