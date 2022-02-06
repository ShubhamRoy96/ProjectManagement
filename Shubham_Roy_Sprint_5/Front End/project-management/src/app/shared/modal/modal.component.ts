import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { faTimes } from '@fortawesome/free-solid-svg-icons';
import { ApiService } from 'src/app/core/services/api.service';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {

  @Input() innerHTML: string = "";
  @Input() modalTitleText: string = "";
  @Input() path: string = "";
  icoClose = faTimes;
  isNormalButtonsShown: boolean = true;
  navigateTo: string = "";
  isOkayClicked: boolean = false;

  constructor(public activeModal: NgbActiveModal, private apiService: ApiService, private router: Router) { }

  ngOnInit(): void {
  }

  performOK(): Observable<boolean> {
    // if (this.path != "") {
    //   let httpOptions: Object = {
    //     responseType: 'text'
    //   }
    //   this.apiService.delete(this.path, httpOptions).subscribe(data => this.deleteSuccess(data));
    // }
    return of(this.isOkayClicked = true);
  }

  deleteSuccess(message: string){
    console.log(message)
    this.innerHTML = message;
    this.isNormalButtonsShown = !this.isNormalButtonsShown;
  }

  closeModal(){
    if(this.navigateTo)
    {
      this.router.navigate([this.navigateTo])
    }
    this.activeModal.close();
  }
}
