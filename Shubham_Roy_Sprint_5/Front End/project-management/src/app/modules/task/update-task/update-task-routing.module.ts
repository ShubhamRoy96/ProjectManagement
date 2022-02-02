import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule, Router } from '@angular/router';
import { UpdateTaskComponent } from './update-task.component';
const updateTaskRoutes: Routes = [
  {
    path: '',
    component: UpdateTaskComponent

  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(updateTaskRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class updateTaskRoutingModule { }
