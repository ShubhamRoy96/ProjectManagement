import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

const appRoutes: Routes = [
  {
    path: 'users',
    loadChildren: () => import('./modules/user/user.module').then(module => module.UserModule)
  },
  {
    path: 'projects',
    loadChildren: () => import('./modules/project/project.module').then(module => module.ProjectModule) 
  },
  {
    path: 'tasks',
    loadChildren: () => import('./modules/task/task.module').then(module => module.TaskModule) 
  }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(
      appRoutes
    )
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
