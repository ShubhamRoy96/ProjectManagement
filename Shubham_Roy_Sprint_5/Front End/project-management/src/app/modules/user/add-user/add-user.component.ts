import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { User } from 'src/app/core';
import { UserService } from 'src/app/core/services/user.service';
import { ModalComponent } from 'src/app/shared';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  firstName: string = "";
  lastName: string = "";
  email: string = "";
  password: string = "";

  constructor(private userService: UserService, private modalService: NgbModal) { }

  ngOnInit(): void {
  }

  addUser(){
    const newUser: User = new User(0, this.firstName, this.lastName, this.email, this.password)
    this.userService.addUser(newUser).subscribe(data => this.userAdded(data))
  }

  userAdded(createdUser: User)
  {
    console.log(createdUser)
    const compInstance = this.modalService.open(ModalComponent).componentInstance;
    compInstance.isNormalButtonsShown = false;
    compInstance.modalTitleText = "Success";
    compInstance.innerHTML = `User <span class="text-primary">${this.firstName + " " + this.lastName}</span> created succesfully</p>`;
    compInstance.navigateTo = 'users/showUsers';
  }

}
