export class Project{
    
    id: number;
    name: string;
    detail: string;
    createdOn: Date;

    constructor(id: number, name: string, detail: string, createdOn: Date){
        this.id = id;
        this.name = name;
        this.detail = detail;
        this.createdOn = createdOn;
    }
}