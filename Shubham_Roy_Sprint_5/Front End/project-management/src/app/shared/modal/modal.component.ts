import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { faTimes } from '@fortawesome/free-solid-svg-icons';
import { ApiService } from 'src/app/core/services/api.service';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {

  @Input() innerHTML: string = "";
  @Input() path: string = "";
  icoClose = faTimes;
  isNormalButtonsShown: boolean = true;

  constructor(public activeModal: NgbActiveModal, private apiService: ApiService) { }

  ngOnInit(): void {
  }

  performOK() {
    if (this.path != "") {
      let httpOptions: Object = {
        responseType: 'text'
      }
      this.apiService.delete(this.path, httpOptions).subscribe(data => this.deleteSuccess(data));
    }
  }

  deleteSuccess(message: string){
    console.log(message)
    this.innerHTML = message;
    this.isNormalButtonsShown = !this.isNormalButtonsShown;
  }
}
