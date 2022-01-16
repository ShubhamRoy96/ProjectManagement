import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule, Router } from '@angular/router';
import { ProjectComponent } from './project.component';

const projectRoutes: Routes = [
  {
    path: '',
    component: ProjectComponent
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
