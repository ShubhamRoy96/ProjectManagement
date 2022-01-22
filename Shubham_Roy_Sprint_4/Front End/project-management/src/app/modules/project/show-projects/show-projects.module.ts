import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { showProjectRoutingModule } from './show-project-routing.module';
import { ShowProjectsComponent } from './show-projects.component';



@NgModule({
  declarations: [
    ShowProjectsComponent
  ],
  imports: [
    CommonModule,
    showProjectRoutingModule
  ]
})
export class ShowProjectsModule { }
