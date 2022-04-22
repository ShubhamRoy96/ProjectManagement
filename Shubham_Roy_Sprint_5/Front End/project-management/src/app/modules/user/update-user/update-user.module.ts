import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UpdateUserComponent } from './update-user.component';
import { updateUsersRoutingModule } from './update-user-routing.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    UpdateUserComponent
  ],
  imports: [
    CommonModule,
    updateUsersRoutingModule,
    FormsModule
  ]
})
export class UpdateUserModule { }
