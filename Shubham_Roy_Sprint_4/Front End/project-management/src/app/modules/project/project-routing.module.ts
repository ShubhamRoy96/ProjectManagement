import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule, Router } from '@angular/router';
import { ProjectComponent } from './project.component';
import { ShowProjectsComponent } from './show-projects/show-projects.component';
import { AddProjectComponent } from './add-project/add-project.component';

const projectRoutes: Routes = [
  {
    path: '',
    component: ProjectComponent,
    children:[
      {
        path: 'showProjects',
        component: ShowProjectsComponent
      },
      {
        path: 'addProject',
        component: AddProjectComponent
      }
    ]
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(projectRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class ProjectRoutingModule { }
