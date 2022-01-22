import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { faTimes } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {

  @Input() innerHTML: string = "";
  icoClose = faTimes;
  
  constructor(public activeModal: NgbActiveModal) {}

  ngOnInit(): void {
  }

  performOK(){
    console.log("deleted")
  }
}
