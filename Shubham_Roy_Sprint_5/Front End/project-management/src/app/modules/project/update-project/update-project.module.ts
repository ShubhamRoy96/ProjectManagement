import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { updateProjectRoutingModule } from './update-project-routing.module';
import { UpdateProjectComponent } from './update-project.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    UpdateProjectComponent
  ],
  imports: [
    CommonModule,
    updateProjectRoutingModule,
    FormsModule
  ]
})
export class UpdateProjectModule { }
