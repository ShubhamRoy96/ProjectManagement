import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtService } from 'src/app/core/services/jwt.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(public router: Router, private jwtService: JwtService) { }

  ngOnInit(): void {
  }

  logout(){
    this.jwtService.purgeToken();
    this.router.navigate(['login'])
  }
}
