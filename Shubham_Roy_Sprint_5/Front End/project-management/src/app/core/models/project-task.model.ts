export class ProjectTask{
    
    id: number;
    projectId: number;
    status: number;
    assignedToUser: number;
    detail: string;
    createdOn?: Date;

    constructor(id: number, projectId: number, status: number, assignedToUser: number, detail: string, createdOn: Date){
        this.id = id;
        this.projectId = projectId;
        this.status = status;
        this.assignedToUser = assignedToUser;
        this.detail = detail;
        this.createdOn = createdOn;
    }

}