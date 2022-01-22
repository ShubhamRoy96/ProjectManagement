import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Project } from 'src/app/core';
import { mockProjects } from './mock-projects';

@Component({
  selector: 'app-show-projects',
  templateUrl: './show-projects.component.html',
  styleUrls: ['./show-projects.component.css']
})
export class ShowProjectsComponent implements OnInit {


  projects: Project[] = []
  constructor(private router: Router) {
    this.projects = mockProjects;
   }


  ngOnInit(): void {
  }

  rowClicked(name: string, detail: string){
    // this.router.navigate(['users/showUsers/test/test/test'])
    this.router.navigate(['projects/', name, detail])
  }
}
