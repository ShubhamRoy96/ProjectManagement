import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { showTasksRoutingModule } from './show-tasks-routing.module';
import { ShowTasksComponent } from './show-tasks.component';



@NgModule({
  declarations: [
    ShowTasksComponent
  ],
  imports: [
    CommonModule,
    showTasksRoutingModule
  ]
})
export class ShowTasksModule { }
