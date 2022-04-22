import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddTaskComponent } from './add-task.component';
import { AddTaskRoutingModule } from './add-task-routing.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AddTaskComponent
  ],
  imports: [
    CommonModule,
    AddTaskRoutingModule,
    FormsModule
  ]
})
export class AddTaskModule { }
