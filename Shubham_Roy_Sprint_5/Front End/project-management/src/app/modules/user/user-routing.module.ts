import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule, Router } from '@angular/router';
import { UserComponent } from './user.component';
import { AddUserComponent } from './add-user/add-user.component';
import { ShowUsersComponent } from './show-users/show-users.component';
import { UpdateUserComponent } from './update-user/update-user.component';

const userRoutes: Routes = [
  {
    path: '',
    component: UserComponent,
    children: [
      {
        path: 'addUser',
        loadChildren: ()=> import('./add-user/add-user.module').then(m => m.AddUserModule)
      },
      {
        path: 'showUsers',
        loadChildren: ()=> import('./show-users/show-users.module').then(m => m.showUserModule)
      },
      {
        path: ':firstName/:lastName/:email',
        loadChildren: ()=> import('./update-user/update-user.module').then(m => m.UpdateUserModule)
      }
    ]
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(userRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class UserRoutingModule { }
