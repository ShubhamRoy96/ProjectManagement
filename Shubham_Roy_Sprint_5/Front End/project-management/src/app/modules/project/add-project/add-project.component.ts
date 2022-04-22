import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Project } from 'src/app/core';
import { ProjectService } from 'src/app/core/services/project.service';
import { ModalComponent } from 'src/app/shared';

@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.css']
})
export class AddProjectComponent implements OnInit {

  projectName: string = "";
  detail: string = "";
  createdOn: Date = new Date();
  constructor(private projectService: ProjectService, private modalService: NgbModal) { }

  ngOnInit(): void {
  }

  addProject(){
    const newProject: Project = new Project(0, this.projectName, this.detail, this.createdOn)
    this.projectService.addProject(newProject).subscribe(data => this.ProjectAdded(data))
  }

  ProjectAdded(createdProject: Project)
  {
    console.log(createdProject)
    const compInstance = this.modalService.open(ModalComponent).componentInstance;
    compInstance.isNormalButtonsShown = false;
    compInstance.modalTitleText = "Success";
    compInstance.innerHTML = `Project <span class="text-primary">${createdProject.name}</span> created succesfully</p>`;
    compInstance.navigateTo = 'projects/showProjects';
  }
}
