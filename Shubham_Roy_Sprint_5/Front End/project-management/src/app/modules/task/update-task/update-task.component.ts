import { Component, HostListener, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProjectTask } from 'src/app/core';
import { TaskService } from 'src/app/core/services/task.service';
import { ModalComponent } from 'src/app/shared';

@Component({
  selector: 'app-update-task',
  templateUrl: './update-task.component.html',
  styleUrls: ['./update-task.component.css']
})
export class UpdateTaskComponent implements OnInit {

  id: number = 0;
  project: number = 0;
  assignedToUser: number = 0;
  status: number = 0;
  detail: string = "";

  constructor(private currentRoute: ActivatedRoute, private modalService: NgbModal, private taskService: TaskService) {
    this.currentRoute.params.subscribe((params) => {
      this.id = params['id']
      // this.project = params['project']
      // this.assignedToUser = params['assignedToUser']
      // this.status = params['status']
      // this.detail = params['detail']
    });
  }
  ngOnInit(): void {
    this.taskService.getTask(Number(this.id)).subscribe(data => this.setTask(data))
  }

  setTask(task: ProjectTask) {
    this.project = task.projectID;
    this.assignedToUser = task.assignedToUserID;
    this.status = task.status;
    this.detail = task.detail;
  }

  updateTask() {
    const updatedTask: ProjectTask = new ProjectTask(this.id, this.project, this.status, this.assignedToUser, this.detail, new Date());
    this.taskService.updateTask(updatedTask).subscribe(data => this.TaskUpdated(data))
  }

  TaskUpdated(updatedTask: ProjectTask) {
    console.log(updatedTask);
    const compInstance = this.modalService.open(ModalComponent).componentInstance;
    compInstance.isNormalButtonsShown = false;
    compInstance.modalTitleText = "Success";
    compInstance.innerHTML = `Task <span class="text-primary">${this.id}</span> updated succesfully</p>`;
    compInstance.navigateTo = 'tasks/showTasks';
  }

  @HostListener('window:click', ['$event'])
  onWindowClick(event: Event) {
    if ((event.target as HTMLButtonElement).id == "confirmOperation") {
      this.deleteTask();
    }
  }

  confirmDeletion() {

    const modalRef = this.modalService.open(ModalComponent);
    var compInstance = modalRef.componentInstance;
    compInstance.modalTitleText = "Task Deletion";
    compInstance.innerHTML = `<strong>Are you sure you want to delete the Task <span class="text-primary">${this.id}</span> ?</strong></p>
    <p>All information associated to this Task will be permanently deleted.
    <span class="text-danger">This operation can not be undone.</span>`;
  }

  deleteTask() {
    let httpOptions: Object = {
      responseType: 'text'
    }
    this.taskService.deleteTask(this.id.toString(), httpOptions).subscribe(data => this.taskDeleted(data))
  }

  taskDeleted(message: string) {
    const modalRef = this.modalService.open(ModalComponent);
    var compInstance = modalRef.componentInstance;
    compInstance.isNormalButtonsShown = false;
    compInstance.modalTitleText = "Success";
    compInstance.innerHTML = message
    compInstance.navigateTo = "/tasks/showTasks";
  }
}
