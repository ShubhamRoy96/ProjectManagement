import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule, Router } from '@angular/router';
import { TaskComponent } from './task.component';
import { ShowTasksComponent } from './show-tasks/show-tasks.component';
import { AddTaskComponent } from './add-task/add-task.component';

const taskRoutes: Routes = [
  {
    path: '',
    component: TaskComponent,
    children:[
      {
        path: 'showTasks',
        component: ShowTasksComponent
      },
      {
        path: 'addTask',
        component: AddTaskComponent
      }
    ]
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(taskRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class TaskRoutingModule { }
