import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { ErrorPageComponent } from './error-page.component';

const errorPageRoutes: Routes = [
  {
    path: '',
    component: ErrorPageComponent
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(errorPageRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class ErrorPageRoutingModule { }
