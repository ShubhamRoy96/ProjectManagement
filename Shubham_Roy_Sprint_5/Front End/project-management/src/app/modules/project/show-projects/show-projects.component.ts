import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Project } from 'src/app/core';
import { ApiService } from 'src/app/core/services/api.service';
import { ProjectService } from 'src/app/core/services/project.service';
import { mockProjects } from './mock-projects';

@Component({
  selector: 'app-show-projects',
  templateUrl: './show-projects.component.html',
  styleUrls: ['./show-projects.component.css']
})
export class ShowProjectsComponent implements OnInit {


  projects: Project[] = []
  constructor(private router: Router, private projectService: ProjectService) {}


  ngOnInit(): void {
    this.projectService.getAllProjects().subscribe(data => this.projects = data)
  }

  rowClicked(id: number, name: string, detail: string){
    this.router.navigate(['projects/', id, name, detail])
  }
}
