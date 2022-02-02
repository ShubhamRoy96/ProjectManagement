import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UpdateTaskComponent } from './update-task.component';
import { updateTaskRoutingModule } from './update-task-routing.module';



@NgModule({
  declarations: [
    UpdateTaskComponent
  ],
  imports: [
    CommonModule,
    updateTaskRoutingModule
  ]
})
export class UpdateTaskModule { }
