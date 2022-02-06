import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { faArrowRight, faUser, faUnlock } from '@fortawesome/free-solid-svg-icons';
import { map } from 'rxjs';
import { User } from 'src/app/core';
import { ApiService } from 'src/app/core/services/api.service';
import { JwtService } from 'src/app/core/services/jwt.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {

  icoArrow = faArrowRight;
  icoEmail = faUser;
  icoPass = faUnlock;
  loginForm: FormGroup;

  constructor(private router : Router, private route: ActivatedRoute, private apiService: ApiService, private frmBuilder: FormBuilder, private jwtService: JwtService) {
    this.loginForm = frmBuilder.group(
      {
        'email':['', Validators.required],
        'password': ['', Validators.required]
      }
    ); 
   }

  ngOnInit(): void {
  }

  submitForm(){
    const creds = this.loginForm.value;
    console.log(creds)
    console.log(creds.email)
    console.log(creds.password)
    let adminUser = new User(
      0,
      "test",
      "test",
      creds.email,
      creds.password
    )
    console.log(adminUser)

    let httpOptions:Object = {

      headers: new HttpHeaders({
          'Content-Type': 'application/json'
      }),
      responseType: 'text'
   }
    this.apiService.post('/Authentication/Login', adminUser, httpOptions).subscribe(data => this.onLoginSuccess(data))
    
  }

  onLoginSuccess(token: string){
    console.log('login success')
    this.jwtService.saveToken(token);
    this.router.navigate(['users/showUsers'])
  }
}
