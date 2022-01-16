import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/core';
import { mockUsers } from './mock-users';

@Component({
  selector: 'app-show-users',
  templateUrl: './show-users.component.html',
  styleUrls: ['./show-users.component.css']
})
export class ShowUsersComponent implements OnInit {

  users: User[] = []
  constructor() {
    this.users = mockUsers;
   }

  ngOnInit(): void {
  }

}
