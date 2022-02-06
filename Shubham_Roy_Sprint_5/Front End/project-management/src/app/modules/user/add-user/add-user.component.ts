import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/core';
import { ApiService } from 'src/app/core/services/api.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  firstName: string = "";
  lastName: string = "";
  email: string = "";
  password: string = "";

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
  }

  addUser(){

    const newUser: User = new User(0, this.firstName, this.lastName, this.email, this.password)

    let httpOptions: Object = {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json'
        }       
      )
    }
    this.apiService.post('/User', newUser, httpOptions).subscribe(data => console.log(data))
  }

}
