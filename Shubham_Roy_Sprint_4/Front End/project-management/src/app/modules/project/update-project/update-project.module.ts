import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { updateProjectRoutingModule } from './update-project-routing.module';
import { UpdateProjectComponent } from './update-project.component';



@NgModule({
  declarations: [
    UpdateProjectComponent
  ],
  imports: [
    CommonModule,
    updateProjectRoutingModule
  ]
})
export class UpdateProjectModule { }
