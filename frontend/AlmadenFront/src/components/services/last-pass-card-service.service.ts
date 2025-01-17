import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { env } from '../environments/env'; 
import { LastPassCard } from '../interface/LastPassCard'; 


@Injectable({
  providedIn: 'root'
})
export class LastPassCardServiceService {
  private apiUrl: string;

  constructor(private http: HttpClient) {
    this.apiUrl = env.AlmadenApiUrl; 
  }
   createLastPassCard(cardData: LastPassCard): Observable<any> {
    const headers = new HttpHeaders({
      'Accept': '*/*',
      'Content-Type': 'application/json'
    });

    return this.http.post<any>(this.apiUrl, cardData, { headers });
  }

}



// import { Injectable } from '@angular/core';
// import { Observable } from 'rxjs';


// @Injectable({
//   providedIn: 'root'
// })
// export class UserServiceService {
//   private apiUrl: string;

//   constructor(private http: HttpClient) {
//     this.apiUrl = env.AlmadenApiUrl; 
//   }

//   authenticate(user: User): Observable<HttpResponse<any>> {
//     const url = `${this.apiUrl}/api/User/auth`;
//     return this.http.post<HttpResponse<any>>(url, user, {
//       observe: 'response',  // Isso retorna a resposta completa (status, headers, body)
//       headers: {
//         'Accept': '*/*',
//         'Content-Type': 'application/json'
//       }
//     });
//   }
  