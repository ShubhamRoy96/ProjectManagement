export class ProjectTask{
    
    id: number;
    projectID: number;
    status: number;
    assignedToUserID: number;
    detail: string;
    createdOn?: Date;

    constructor(id: number, projectId: number, status: number, assignedToUser: number, detail: string, createdOn: Date){
        this.id = id;
        this.projectID = projectId;
        this.status = status;
        this.assignedToUserID = assignedToUser;
        this.detail = detail;
        this.createdOn = createdOn;
    }

}

export enum statuses {
    New = 1,
    "In Progress" = 2,
    QA = 3,
    Completed = 4
  }