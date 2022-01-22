import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from 'src/app/shared';

@Component({
  selector: 'app-update-project',
  templateUrl: './update-project.component.html',
  styleUrls: ['./update-project.component.css']
})
export class UpdateProjectComponent implements OnInit {

  name: string = "";
  detail: string = "";

  constructor(private currentRoute: ActivatedRoute, private modalService: NgbModal) { 
    this.currentRoute.params.subscribe((params) =>
      {
        this.name = params['name']
        this.detail = params['detail']
      });
  }

  ngOnInit(): void {
  }

  open() {
    const modalRef = this.modalService.open(ModalComponent);
    modalRef.componentInstance.innerHTML = `<strong>Are you sure you want to delete Project : <span class="text-primary">${this.name}</span> ?</strong></p>
    <p>All information associated to this project will be permanently deleted.
    <span class="text-danger">This operation can not be undone.</span>`;
  }
}
