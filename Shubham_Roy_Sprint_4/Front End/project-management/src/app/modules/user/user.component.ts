import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/core';
import { mockUsers } from './mock-users';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  users: User[] = mockUsers; //To be replaced by a dedicated service in Sprint-5
  constructor() { }

  ngOnInit(): void {
  }

}
