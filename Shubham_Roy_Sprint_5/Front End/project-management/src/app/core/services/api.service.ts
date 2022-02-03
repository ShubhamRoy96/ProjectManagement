import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http'
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }
  
  private formatError(error: any){
    return throwError(() => new Error(error));
  }
  
  get(path: string, params: HttpParams = new HttpParams()): Observable<any>{
    return this.http.get(`${environment.api_url}${path}`, { params }).pipe(catchError(this.formatError))
  }

  put(){

  }


  post(){

  }

  delete(){
    
  }
}
