import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { env } from '../environments/env'; 
import { User } from '../interface/User'; 

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  private apiUrl: string;

  constructor(private http: HttpClient) {
    this.apiUrl = env.AlmadenApiUrl; 
  }

  authenticate(user: User): Observable<HttpResponse<any>> {
    const url = `${this.apiUrl}/api/User/auth`;
    return this.http.post<HttpResponse<any>>(url, user, {
      observe: 'response',  // Isso retorna a resposta completa (status, headers, body)
      headers: {
        'Accept': '*/*',
        'Content-Type': 'application/json'
      }
    });
  }
  



}
