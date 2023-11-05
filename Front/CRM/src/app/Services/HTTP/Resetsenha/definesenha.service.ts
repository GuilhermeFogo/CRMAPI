import { User } from '../../../Modal/User';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DefineSenhaService {
  private http: HttpClient;
  private url: string;
  constructor(http: HttpClient) {
    this.http = http;
    this.url = environment.Local + "/api/ResetsenhaUser/Define/"
  }

  public PostEmail(usuario: User){
    const myheader = new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8');
    return this.http.post(this.url, usuario,{
      headers: myheader,
      observe:'body',
      responseType: 'text' as 'json'
    });
  }
}
