import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule, Router } from '@angular/router';
import { UpdateProjectComponent } from './update-project.component';
const updateProjectRoutes: Routes = [
  {
    path: '',
    component: UpdateProjectComponent

  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(updateProjectRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class updateProjectRoutingModule { }
