import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProjectTask } from 'src/app/core';
import { ApiService } from 'src/app/core/services/api.service';
import { TaskService } from 'src/app/core/services/task.service';
import { mockTasks } from './mock-tasks';

@Component({
  selector: 'app-show-tasks',
  templateUrl: './show-tasks.component.html',
  styleUrls: ['./show-tasks.component.css']
})
export class ShowTasksComponent implements OnInit {

  projectTasks: ProjectTask[] = []
  constructor(private router: Router, private taskService: TaskService) {
   }


  ngOnInit(): void {
    this.taskService.getAllTasks().subscribe(data => this.projectTasks = data)
  }

  rowClicked(id: any){
    this.router.navigate(['tasks/', id])
  }
}
