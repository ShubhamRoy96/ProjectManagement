import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule, Router } from '@angular/router';
import { UpdateUserComponent } from './update-user.component';
const updateUsersRoutes: Routes = [
  {
    path: '',
    component: UpdateUserComponent

  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(updateUsersRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class updateUsersRoutingModule { }
