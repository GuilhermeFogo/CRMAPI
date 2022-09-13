import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OportunidadesService {

  private readonly http: HttpClient;
  private readonly url: string;
  constructor(http: HttpClient) {
    this.http = http;
    this.url = environment.Local+ "";
   }

   
}
