import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { faArrowRight, faUser, faUnlock } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {


  icoArrow = faArrowRight;
  icoEmail = faUser;
  icoPass = faUnlock;
  constructor(private router : Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
  }

  submitForm(){
    this.router.navigate(['users/showUsers']).then(() => window.location.reload());
  }
}
