import { Component, OnInit } from '@angular/core';
import { Project } from 'src/app/core';
import { mockProjects } from './mock-projects';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {

  projects: Project[] = mockProjects;
  constructor() { }

  ngOnInit(): void {
  }

}
