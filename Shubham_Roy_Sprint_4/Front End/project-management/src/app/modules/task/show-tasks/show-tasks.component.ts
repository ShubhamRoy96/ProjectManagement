import { Component, OnInit } from '@angular/core';
import { ProjectTask } from 'src/app/core';
import { mockTasks } from './mock-tasks';

@Component({
  selector: 'app-show-tasks',
  templateUrl: './show-tasks.component.html',
  styleUrls: ['./show-tasks.component.css']
})
export class ShowTasksComponent implements OnInit {

  projectTasks: ProjectTask[] = []
  constructor() {
    this.projectTasks = mockTasks;
   }


  ngOnInit(): void {
  }

}
