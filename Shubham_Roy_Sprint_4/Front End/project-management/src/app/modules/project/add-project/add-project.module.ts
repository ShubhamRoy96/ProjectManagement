import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddProjectComponent } from './add-project.component';
import { addProjectRoutingModule } from './add-project-routing.module';



@NgModule({
  declarations: [
    AddProjectComponent
  ],
  imports: [
    CommonModule,
    addProjectRoutingModule
  ]
})
export class AddProjectModule { }
