import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule, Router } from '@angular/router';
import { ShowProjectsComponent } from './show-projects.component';
const showProjectRoutes: Routes = [
  {
    path: '',
    component: ShowProjectsComponent

  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(showProjectRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class showProjectRoutingModule { }
