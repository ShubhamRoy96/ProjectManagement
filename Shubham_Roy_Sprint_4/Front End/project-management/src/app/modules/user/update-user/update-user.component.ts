import { ConstantPool } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { User } from 'src/app/core';
import { ModalComponent } from 'src/app/shared';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.css']
})
export class UpdateUserComponent implements OnInit {

  firstName: string = "";
  lastName: string = "";
  email: string = "";
  constructor(private currentRoute: ActivatedRoute, private modalService: NgbModal) {
    this.currentRoute.params.subscribe((params) =>
      {
        this.firstName = params['firstName']
        this.lastName = params['lastName']
        this.email = params['email']
      });
   }

  ngOnInit(): void {

  }

  open() {
    const modalRef = this.modalService.open(ModalComponent);
    modalRef.componentInstance.innerHTML = `<strong>Are you sure you want to delete <span class="text-primary">${this.firstName + " " + this.lastName}</span> profile?</strong></p>
    <p>All information associated to this user profile will be permanently deleted.
    <span class="text-danger">This operation can not be undone.</span>`;
  }

}
