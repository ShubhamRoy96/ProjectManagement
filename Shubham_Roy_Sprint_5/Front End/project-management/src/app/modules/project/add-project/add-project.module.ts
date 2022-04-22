import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddProjectComponent } from './add-project.component';
import { addProjectRoutingModule } from './add-project-routing.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AddProjectComponent
  ],
  imports: [
    CommonModule,
    addProjectRoutingModule,
    FormsModule
  ]
})
export class AddProjectModule { }
