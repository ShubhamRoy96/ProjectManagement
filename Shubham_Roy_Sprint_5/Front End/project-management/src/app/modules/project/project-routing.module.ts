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
        loadChildren: ()=> import('./show-projects/show-projects.module').then(m => m.ShowProjectsModule)
      },
      {
        path: 'addProject',
        loadChildren: ()=> import('./add-project/add-project.module').then(m => m.AddProjectModule)
      },
      {
        path: ':id/:name/:detail',
        loadChildren: ()=> import('./update-project/update-project.module').then(m => m.UpdateProjectModule)
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
