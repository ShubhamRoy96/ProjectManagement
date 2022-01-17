import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskComponent } from './task.component';
import { TaskRoutingModule } from './task-routing.module';
import { AddTaskComponent } from './add-task/add-task.component';
import { ShowTasksComponent } from './show-tasks/show-tasks.component';



@NgModule({
  declarations: [
    TaskComponent,
    AddTaskComponent,
    ShowTasksComponent
  ],
  imports: [
    CommonModule,
    TaskRoutingModule
  ]
})
export class TaskModule { }
