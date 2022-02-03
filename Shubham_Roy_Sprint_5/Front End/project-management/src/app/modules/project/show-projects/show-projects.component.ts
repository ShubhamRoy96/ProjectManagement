import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Project } from 'src/app/core';
import { ApiService } from 'src/app/core/services/api.service';
import { mockProjects } from './mock-projects';

@Component({
  selector: 'app-show-projects',
  templateUrl: './show-projects.component.html',
  styleUrls: ['./show-projects.component.css']
})
export class ShowProjectsComponent implements OnInit {


  projects: Project[] = []
  constructor(private router: Router, private apiService: ApiService) {
    // this.projects = mockProjects;
    apiService.get('/Project').subscribe(data => this.projects = data, err => console.log(err))
   }


  ngOnInit(): void {
  }

  rowClicked(name: string, detail: string){
    // this.router.navigate(['users/showUsers/test/test/test'])
    this.router.navigate(['projects/', name, detail])
  }
}
