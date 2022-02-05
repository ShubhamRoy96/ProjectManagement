import { HttpHeaders } from '@angular/common/http';
import { ConstantPool } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { User } from 'src/app/core';
import { ApiService } from 'src/app/core/services/api.service';
import { ModalComponent } from 'src/app/shared';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.css']
})
export class UpdateUserComponent implements OnInit {

  id: string = "";
  firstName: string = "";
  lastName: string = "";
  email: string = "";
  constructor(private currentRoute: ActivatedRoute, private modalService: NgbModal, private apiService: ApiService) {
    this.currentRoute.params.subscribe((params) =>
      {
        this.id = params['id'];
        this.firstName = params['firstName'];
        this.lastName = params['lastName'];
        this.email = params['email'];
      });
   }

  ngOnInit(): void {

  }

  updateUser()
  {
    const user: User = new User(Number(this.id),this.firstName,this.lastName,this.email, null);
    
    let httpOptions:Object = {

      headers: new HttpHeaders({
          'Content-Type': 'application/json'
      })
   }
    this.apiService.put('/User', user, httpOptions).subscribe(data => console.log(data))
  }

  deleteUser() {
    const modalRef = this.modalService.open(ModalComponent);
    modalRef.componentInstance.path = `/User?ID=${this.id}`
    modalRef.componentInstance.innerHTML = `<strong>Are you sure you want to delete <span class="text-primary">${this.firstName + " " + this.lastName}</span> profile?</strong></p>
    <p>All information associated to this user profile will be permanently deleted.
    <span class="text-danger">This operation can not be undone.</span>`;
  }

}
