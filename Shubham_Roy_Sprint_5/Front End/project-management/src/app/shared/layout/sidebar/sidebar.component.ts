import { Component, OnInit } from '@angular/core';
import { faHouseUser, faProjectDiagram, faTasks, faUsers } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  icoHome = faHouseUser;
  icoUsers = faUsers;
  icoTasks = faTasks;
  icoProjects = faProjectDiagram;
  constructor() { }

  ngOnInit(): void {
  }

}
