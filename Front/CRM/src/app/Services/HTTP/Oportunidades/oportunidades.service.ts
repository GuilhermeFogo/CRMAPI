import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HelperRequests } from 'src/app/Helper/helper-requests';
import { environment } from 'src/environments/environment';
import { CookieService } from '../../cookie/cookie.service';

@Injectable({
  providedIn: 'root'
})
export class OportunidadesService extends HelperRequests {

  private readonly http: HttpClient;
  private readonly url: string;
  constructor(http: HttpClient, cookie: CookieService) {
    super(cookie);
    this.http = http;
    this.url = environment.Local + "";
  }

  public VerOportunidades(): Observable<Oportunidade[]> {
    const header = this.Ajudarequest();
    return this.http.get<Oportunidade[]>(this.url, {
      headers: header
    });
  }

  public PostOportunidade(Oportunidade: Oportunidade): Observable<Oportunidade> {
    const header = this.Ajudarequest();
    return this.http.post<Oportunidade>(this.url, Oportunidade, {
      headers: header
    });
  }

  public PutOportunidade(Oportunidade: Oportunidade): Observable<Oportunidade> {
    const header = this.Ajudarequest();
    return this.http.put<Oportunidade>(this.url + "/" + Oportunidade.Id_oportunidade, Oportunidade, {
      headers: header
    });
  }

  public DeleteOportunidade(Oportunidade: Oportunidade): Observable<Oportunidade> {
    const header = this.Ajudarequest();
    return this.http.delete<Oportunidade>(this.url + "/" + Oportunidade.Id_oportunidade, {
      headers: header
    });
  }

}
