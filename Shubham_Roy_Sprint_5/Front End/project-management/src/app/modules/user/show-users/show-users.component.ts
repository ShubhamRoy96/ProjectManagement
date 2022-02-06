import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/core';
import { ApiService } from 'src/app/core/services/api.service';
import { UserService } from 'src/app/core/services/user.service';
import { mockUsers } from './mock-users';

@Component({
  selector: 'app-show-users',
  templateUrl: './show-users.component.html',
  styleUrls: ['./show-users.component.css']
})
export class ShowUsersComponent implements OnInit {

  users: User[] = []
  constructor(private router: Router, private userService: UserService) {}

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe(data => this.users = data)
  }

  rowClicked(id: number){
    this.router.navigate(['users/', id])
  }

}
