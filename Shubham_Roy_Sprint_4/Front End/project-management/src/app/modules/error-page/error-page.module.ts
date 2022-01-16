import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ErrorPageRoutingModule } from './error-page-routing.module';
import { ErrorPageComponent } from './error-page.component';



@NgModule({
  declarations: [
    ErrorPageComponent
  ],
  imports: [
    FontAwesomeModule,
    ErrorPageRoutingModule
  ]
})
export class ErrorPageModule { }
