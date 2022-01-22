import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProjectTask } from 'src/app/core';
import { mockTasks } from './mock-tasks';

@Component({
  selector: 'app-show-tasks',
  templateUrl: './show-tasks.component.html',
  styleUrls: ['./show-tasks.component.css']
})
export class ShowTasksComponent implements OnInit {

  projectTasks: ProjectTask[] = []
  constructor(private router: Router) {
    this.projectTasks = mockTasks;
   }


  ngOnInit(): void {
  }

  rowClicked(project: number, assignedToUser: number, status: number, detail: string){
    this.router.navigate(['tasks/', project, assignedToUser, status, detail])
  }
}
