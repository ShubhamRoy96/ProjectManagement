import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule, Router } from '@angular/router';
import { ShowUsersComponent } from './show-users.component';

const showUsersRoutes: Routes = [
  {
    path: '',
    component: ShowUsersComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(showUsersRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class showUsersRoutingModule { }
