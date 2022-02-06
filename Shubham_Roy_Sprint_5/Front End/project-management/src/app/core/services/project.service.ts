import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Project } from '..';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  constructor(private apiService: ApiService) { }

  addProject(newProject: Project): Observable<Project>{
    let httpOptions: Object = {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json'
        }       
      )
    }
    return this.apiService.post('/Project', newProject, httpOptions)
  }

  getAllProjects(): Observable<Array<Project>>{
    let httpOptions: Object = {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json'
        }       
      )
    }
    return this.apiService.get('/Project', undefined, httpOptions)
  }

  getProject(id: number): Observable<Project>{
    let httpOptions: Object = {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json'
        }       
      )
    }
    return this.apiService.get(`/Project/${id}`, undefined, httpOptions)
  }

  updateProject(updatedProject: Project): Observable<Project>{
    let httpOptions: Object = {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json'
        }       
      )
    }
    return this.apiService.put('/Project', updatedProject, httpOptions)
  }

  deleteProject(id: string, httpOptions?: Object): Observable<any>{
    return this.apiService.delete(`/Project/?ID=${id}`, httpOptions)
  }
}
