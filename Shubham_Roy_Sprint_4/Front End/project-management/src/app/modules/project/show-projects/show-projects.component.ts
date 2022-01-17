import { Component, OnInit } from '@angular/core';
import { Project } from 'src/app/core';
import { mockProjects } from './mock-projects';

@Component({
  selector: 'app-show-projects',
  templateUrl: './show-projects.component.html',
  styleUrls: ['./show-projects.component.css']
})
export class ShowProjectsComponent implements OnInit {


  projects: Project[] = []
  constructor() {
    this.projects = mockProjects;
   }


  ngOnInit(): void {
  }

}
