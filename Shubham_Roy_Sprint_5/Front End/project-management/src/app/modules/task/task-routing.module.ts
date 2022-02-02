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
        loadChildren: ()=> import('./show-tasks/show-tasks.module').then(m => m.ShowTasksModule)
      },
      {
        path: 'addTask',
        loadChildren: ()=> import('./add-task/add-task.module').then(m => m.AddTaskModule)
      },
      {
        path: ':project/:assignedToUser/:status/:detail',
        loadChildren: ()=> import('./update-task/update-task.module').then(m => m.UpdateTaskModule)
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
