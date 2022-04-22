import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UpdateTaskComponent } from './update-task.component';
import { updateTaskRoutingModule } from './update-task-routing.module';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';



@NgModule({
  declarations: [
    UpdateTaskComponent
  ],
  imports: [
    CommonModule,
    updateTaskRoutingModule,
    FormsModule,
    NgbModule
  ]
})
export class UpdateTaskModule { }
