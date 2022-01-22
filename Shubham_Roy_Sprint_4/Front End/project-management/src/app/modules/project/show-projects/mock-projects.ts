import { Project } from "src/app/core";

export const mockProjects: Project[] = [
    new Project(1, "Name 1", "Detail 1", new Date(2020,1,22)),
    new Project(2, "Name 2", "Detail 2", new Date(2021,1,24)),
    new Project(3, "Name 3", "Detail 3", new Date(2020,6,12)),
    new Project(4, "Name 4", "Detail 4", new Date(2022,1,14))
]