import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from 'src/app/shared';

@Component({
  selector: 'app-update-task',
  templateUrl: './update-task.component.html',
  styleUrls: ['./update-task.component.css']
})
export class UpdateTaskComponent implements OnInit {

  firstName: string = "";
  lastName: string = "";
  email: string = "";

  project: number = 0;
  assignedToUser: number = 0;
  status: number = 0;
  detail: string = "";

  constructor(private currentRoute: ActivatedRoute, private modalService: NgbModal) {
    this.currentRoute.params.subscribe((params) =>
      {
        this.project = params['project']
        this.assignedToUser = params['assignedToUser']
        this.status = params['status']
        this.detail = params['detail']
      });
   }
  ngOnInit(): void {
  }

  deleteTask() {
    const modalRef = this.modalService.open(ModalComponent);
    modalRef.componentInstance.innerHTML = `<strong>Are you sure you want to delete Task : <span class="text-primary">${this.project}</span>?</strong></p>
    <p>All information associated to this task will be permanently deleted.
    <span class="text-danger">This operation can not be undone.</span>`;
  }
}
