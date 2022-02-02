import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule, Router } from '@angular/router';
import { AddUserComponent } from './add-user.component';

const addUserRoutes: Routes = [
  {
    path: '',
    component: AddUserComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(addUserRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class AddUserRoutingModule { }
