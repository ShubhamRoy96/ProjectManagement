import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http'
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }
  
  get(path: string, params: HttpParams = new HttpParams(), httpOptions?: Object): Observable<any>{
    return this.http.get(`${environment.api_url}${path}`, { params })
  }

  put(path: string, body: Object = {}, httpOptions?: Object): Observable<any>{
    return this.http.put(`${environment.api_url}${path}`, JSON.stringify(body), httpOptions)
  }

  post(path: string, body: Object = {}, httpOptions?: Object): Observable<any>{    
    return this.http.post(`${environment.api_url}${path}`, JSON.stringify(body), httpOptions)
  }

  delete(path: string, httpOptions?: Object): Observable<any>{
    return this.http.delete(`${environment.api_url}${path}`, httpOptions)
  }
}
