import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProjectTask } from 'src/app/core';
import { ApiService } from 'src/app/core/services/api.service';
import { mockTasks } from './mock-tasks';

@Component({
  selector: 'app-show-tasks',
  templateUrl: './show-tasks.component.html',
  styleUrls: ['./show-tasks.component.css']
})
export class ShowTasksComponent implements OnInit {

  projectTasks: ProjectTask[] = []
  constructor(private router: Router, private apiService: ApiService) {
    // this.projectTasks = mockTasks;
    apiService.get('/Task').subscribe(data => this.projectTasks = data, err => console.log(err))
   }


  ngOnInit(): void {
  }

  rowClicked(project: any, assignedToUser: any, status: number, detail: string){
    this.router.navigate(['tasks/', project, assignedToUser, status, detail])
  }
}
