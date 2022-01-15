import { Component, OnInit } from '@angular/core';
import { ProjectTask } from 'src/app/core';
import { mockTasks } from './mock-tasks';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {

 projectTasks: ProjectTask[] = mockTasks;

  constructor() { }

  ngOnInit(): void {
  }

}
