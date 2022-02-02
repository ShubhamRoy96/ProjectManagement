import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/core';
import { mockUsers } from './mock-users';

@Component({
  selector: 'app-show-users',
  templateUrl: './show-users.component.html',
  styleUrls: ['./show-users.component.css']
})
export class ShowUsersComponent implements OnInit {

  users: User[] = []
  constructor(private router: Router) {
    this.users = mockUsers;
   }

  ngOnInit(): void {
  }

  rowClicked(firstName: string, lastName: string, email: string){
    // this.router.navigate(['users/showUsers/test/test/test'])
    this.router.navigate(['users/', firstName, lastName, email])
  }

}
