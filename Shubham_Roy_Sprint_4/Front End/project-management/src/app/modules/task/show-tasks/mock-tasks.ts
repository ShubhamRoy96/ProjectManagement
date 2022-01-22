import { ProjectTask } from "src/app/core";

export const mockTasks: ProjectTask[] = [
{
    id: 1,
    projectId: 1,
    status: 1,
    assignedToUser: 1,
    detail: "Task 1 Details",
    createdOn: new Date(2020,2,12)
},
{
    id: 2,
    projectId: 2,
    status: 2,
    assignedToUser: 2,
    detail: "Task 2 Details",
    createdOn: new Date(2020,2,22)
},
{
    id: 3,
    projectId: 3,
    status: 3,
    assignedToUser: 3,
    detail: "Task 3 Details",
    createdOn: new Date(2020,3,12)
},
{
    id: 4,
    projectId: 4,
    status: 4,
    assignedToUser: 4,
    detail: "Task 4 Details",
    createdOn: new Date(2021,4,12)
}
]