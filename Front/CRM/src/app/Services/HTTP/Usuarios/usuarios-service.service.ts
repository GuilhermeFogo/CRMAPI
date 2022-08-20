import { Observable } from 'rxjs';
import { User } from './../../../Modal/User';
import { CookieService } from './../../cookie/cookie.service';
import { environment } from './../../../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HelperRequests } from 'src/app/Helper/helper-requests';

@Injectable({
  providedIn: 'root'
})
export class UsuariosServiceService extends HelperRequests {
  private http: HttpClient;
  private url: string;
  constructor(http: HttpClient, cookie: CookieService) {
    super(cookie);
    this.http = http;
    this.url = environment.Local + "/api/Usuario";
  }

  public ListaUser() {

    const header = this.Ajudarequest();
    return this.http.get<User[]>(this.url,{
      headers: header
    });
  }

  public SaveUser(usuario: User) {
    const header = this.Ajudarequest();
    console.log(usuario);
    return this.http.post<User>(this.url, usuario,{
      headers: header
    });
  }

  public UpdateUser(User:User) {
    const header = this.Ajudarequest();
    return this.http.put<User>(this.url+"/"+ User.id, User,{
      headers: header
    });
  }

  public Delete(id: number){
    const header = this.Ajudarequest();
    return this.http.delete(this.url +"/"+ id,{
      headers: header
    });
  }
}
