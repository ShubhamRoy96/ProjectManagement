import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule, Router } from '@angular/router';
import { AddTaskComponent } from './add-task.component';

const addTaskRoutes: Routes = [
  {
    path: '',
    component: AddTaskComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(addTaskRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class AddTaskRoutingModule { }
