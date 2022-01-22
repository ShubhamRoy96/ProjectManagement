import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddTaskComponent } from './add-task.component';
import { AddTaskRoutingModule } from './add-task-routing.module';



@NgModule({
  declarations: [
    AddTaskComponent
  ],
  imports: [
    CommonModule,
    AddTaskRoutingModule
  ]
})
export class AddTaskModule { }
