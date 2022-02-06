import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '..';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private apiService: ApiService) { }

  addUser(newUser: User): Observable<User>{
    let httpOptions: Object = {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json'
        }       
      )
    }
    return this.apiService.post('/User', newUser, httpOptions)
  }

  getAllUsers(): Observable<Array<User>>{
    let httpOptions: Object = {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json'
        }       
      )
    }
    return this.apiService.get('/User', undefined, httpOptions)
  }

  getUser(id: number): Observable<User>{
    let httpOptions: Object = {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json'
        }       
      )
    }
    return this.apiService.get(`/User/${id}`, undefined, httpOptions)
  }

  updateUser(updatedUser: User): Observable<User>{
    let httpOptions: Object = {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json'
        }       
      )
    }
    return this.apiService.put('/User', updatedUser, httpOptions)
  }

  deleteUser(id: string, httpOptions?: Object): Observable<any>{
    return this.apiService.delete(`/User/?ID=${id}`, httpOptions)
  }
}
