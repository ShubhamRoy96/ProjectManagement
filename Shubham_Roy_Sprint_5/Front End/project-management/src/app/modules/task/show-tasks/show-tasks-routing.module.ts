import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule, Router } from '@angular/router';
import { ShowTasksComponent } from './show-tasks.component';

const showTasksRoutes: Routes = [
  {
    path: '',
    component: ShowTasksComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(showTasksRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class showTasksRoutingModule { }
