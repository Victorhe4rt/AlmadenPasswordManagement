import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
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

    return this.http.post<any>(`${this.apiUrl}/api/LastPassCard/`, cardData, { headers });
  }
  getLastPassCardsByUser(userId: number): Observable<LastPassCard[]> {
    const headers = new HttpHeaders({
      'Accept': '*/*'
    });

    return this.http.get<LastPassCard[]>(`${this.apiUrl}/api/LastPassCard/user/${userId}`, { headers });
  }

  deleteLastPassCard(cardId: number): Observable<any> {
    const headers = new HttpHeaders({
      'Accept': '*/*'
    });

    return this.http.delete<any>(`${this.apiUrl}/api/LastPassCard/${cardId}`, { headers });
  }

  updateLastPassCard(cardId: number, updatedCard: any): Observable<any> {
    const headers = new HttpHeaders({
      'Accept': '*/*',
      'Content-Type': 'application/json'
    });
  
    return this.http.put<any>(`${this.apiUrl}/api/LastPassCard/${cardId}`, updatedCard, { headers });
  }


}



