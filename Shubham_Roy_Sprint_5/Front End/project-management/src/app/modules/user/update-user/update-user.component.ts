import { HttpHeaders } from '@angular/common/http';
import { ConstantPool } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { User } from 'src/app/core';
import { ApiService } from 'src/app/core/services/api.service';
import { UserService } from 'src/app/core/services/user.service';
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
  constructor(private currentRoute: ActivatedRoute, private modalService: NgbModal, private userService: UserService) {
    this.currentRoute.params.subscribe((params) => {
      this.id = params['id'];
      this.firstName = params['firstName'];
      this.lastName = params['lastName'];
      this.email = params['email'];
    });
  }

  ngOnInit(): void {

  }

  updateUser() {
    const updatedUser: User = new User(Number(this.id), this.firstName, this.lastName, this.email, null);
    this.userService.updateUser(updatedUser).subscribe(data => this.userUpdated(data))
  }

  userUpdated(updatedUser: User) {
    console.log(updatedUser);
    const compInstance = this.modalService.open(ModalComponent).componentInstance;
    compInstance.isNormalButtonsShown = false;
    compInstance.modalTitleText = "Success";
    compInstance.innerHTML = `User <span class="text-primary">${this.firstName + " " + this.lastName}</span> updated succesfully</p>`;
    compInstance.navigateTo = 'users/showUsers';
  }

  deleteUser() {

    const modalRef = this.modalService.open(ModalComponent);
    var compInstance = modalRef.componentInstance;
    compInstance.modalTitleText = "User Deletion";
    compInstance.innerHTML = `<strong>Are you sure you want to delete <span class="text-primary">${this.firstName + " " + this.lastName}</span> profile?</strong></p>
    <p>All information associated to this user profile will be permanently deleted.
    <span class="text-danger">This operation can not be undone.</span>`;
    compInstance.navigateTo = "/users/showUsers";
    compInstance.performOK().subscribe((data: any) => {
      if (data) {
        let httpOptions: Object = {
          responseType: 'text'
        }
        this.userService.deleteUser(this.id, httpOptions).subscribe(data => compInstance.innerHTML = data)
      }
    })

  }

}
