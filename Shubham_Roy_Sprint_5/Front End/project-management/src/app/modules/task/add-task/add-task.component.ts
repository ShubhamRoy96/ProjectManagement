import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProjectTask } from 'src/app/core';
import { TaskService } from 'src/app/core/services/task.service';
import { ModalComponent } from 'src/app/shared';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})
export class AddTaskComponent implements OnInit {

  id: number = 0;
  projectID: number = 0;
  status: number = 0;
  assignedToUser: number = 0;
  detail: string = "";
  createdOn: Date = new Date(2020, 2, 12)

  constructor(private taskService: TaskService, private modalService: NgbModal) { }

  ngOnInit(): void {
  }

  addTask() {
    const newTask: ProjectTask = new ProjectTask(this.id, this.projectID, this.status, this.assignedToUser, this.detail, this.createdOn)
    this.taskService.addTask(newTask).subscribe(data => this.TaskAdded(data))
  }

  TaskAdded(createdTask: ProjectTask) {
    console.log(createdTask)
    const compInstance = this.modalService.open(ModalComponent).componentInstance;
    compInstance.isNormalButtonsShown = false;
    compInstance.modalTitleText = "Success";
    compInstance.innerHTML = `Task <span class="text-primary">${createdTask.id}</span> created succesfully</p>`;
    compInstance.navigateTo = 'tasks/showTasks';
  }

}
