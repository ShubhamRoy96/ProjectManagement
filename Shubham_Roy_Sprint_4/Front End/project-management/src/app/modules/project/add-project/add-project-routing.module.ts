import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule, Router } from '@angular/router';
import { AddProjectComponent } from './add-project.component';
const addProjectRoutes: Routes = [
  {
    path: '',
    component: AddProjectComponent

  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(addProjectRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class addProjectRoutingModule { }
