import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ProjectTask } from '..';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private apiService: ApiService) { }

  addTask(newTask: ProjectTask): Observable<ProjectTask>{
    let httpOptions: Object = {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json'
        }       
      )
    }
    return this.apiService.post('/Task', newTask, httpOptions)
  }

  getAllTasks(): Observable<Array<ProjectTask>>{
    let httpOptions: Object = {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json'
        }       
      )
    }
    return this.apiService.get('/Task', undefined, httpOptions)
  }

  getTask(): Observable<Array<ProjectTask>>{
    let httpOptions: Object = {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json'
        }       
      )
    }
    return this.apiService.get('/Task', undefined, httpOptions)
  }

  updateTask(updatedTask: ProjectTask): Observable<ProjectTask>{
    let httpOptions: Object = {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json'
        }       
      )
    }
    return this.apiService.put('/Task', updatedTask, httpOptions)
  }

  deleteTask(id: string, httpOptions?: Object): Observable<any>{
    return this.apiService.delete(`/Task/?ID=${id}`, httpOptions)
  }
}
