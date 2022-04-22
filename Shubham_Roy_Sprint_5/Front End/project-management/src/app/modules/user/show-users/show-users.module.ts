import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShowUsersComponent } from './show-users.component';
import { showUsersRoutingModule } from './show-users-routing.module';



@NgModule({
  declarations: [
    ShowUsersComponent
  ],
  imports: [
    CommonModule,
    showUsersRoutingModule
  ]
})
export class showUserModule { }
