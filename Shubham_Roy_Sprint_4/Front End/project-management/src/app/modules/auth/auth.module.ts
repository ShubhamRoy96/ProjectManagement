import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthComponent } from './auth.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AuthRoutingModule } from './auth-routing.module';



@NgModule({
  declarations: [
    AuthComponent
  ],
  imports: [
    CommonModule,
    FontAwesomeModule,
    AuthRoutingModule
  ]
})
export class AuthModule { }
