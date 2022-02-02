import { Component, OnInit } from '@angular/core';
import { faHeart } from '@fortawesome/free-solid-svg-icons';
import { faGithub, faLinkedin } from '@fortawesome/free-brands-svg-icons';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

icoLinkedIn = faLinkedin;
icoHeart = faHeart;
icoGithub = faGithub;
  constructor() { }

  ngOnInit(): void {
  }

}
