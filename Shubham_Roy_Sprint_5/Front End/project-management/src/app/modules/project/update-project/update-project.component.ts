import { Component, HostListener, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Project } from 'src/app/core';
import { ProjectService } from 'src/app/core/services/project.service';
import { ModalComponent } from 'src/app/shared';

@Component({
  selector: 'app-update-project',
  templateUrl: './update-project.component.html',
  styleUrls: ['./update-project.component.css']
})
export class UpdateProjectComponent implements OnInit {

  id: number = 0;
  name: string = "";
  detail: string = "";

  constructor(private currentRoute: ActivatedRoute, private modalService: NgbModal, private projectService: ProjectService) { 
    this.currentRoute.params.subscribe((params) =>
      {
        this.id = params['id']
        // this.name = params['name']
        // this.detail = params['detail']
      });
  }

  ngOnInit(): void {
    this.projectService.getProject(Number(this.id)).subscribe(data => this.setProject(data))  
  }

  setProject(project: Project){
    this.name = project.name;
    this.detail = project.detail;
  }

  updateProject() {
    const updatedProject: Project = new Project(Number(this.id), this.name, this.detail, new Date());
    this.projectService.updateProject(updatedProject).subscribe(data => this.projectUpdated(data))
  }

  projectUpdated(updatedProject: Project) {
    console.log(updatedProject);
    const compInstance = this.modalService.open(ModalComponent).componentInstance;
    compInstance.isNormalButtonsShown = false;
    compInstance.modalTitleText = "Success";
    compInstance.innerHTML = `Project <span class="text-primary">${this.id}</span> updated succesfully</p>`;
    compInstance.navigateTo = 'projects/showProjects';
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
    this.projectService.deleteProject(this.id.toString(), httpOptions).subscribe(data => this.projectDeleted(data))
  }

  projectDeleted(message: string){
    const modalRef = this.modalService.open(ModalComponent);
    var compInstance = modalRef.componentInstance;
    compInstance.isNormalButtonsShown = false;
    compInstance.modalTitleText = "Success";
    compInstance.innerHTML = message
    compInstance.navigateTo = "/tasks/showTasks";
  }
}
