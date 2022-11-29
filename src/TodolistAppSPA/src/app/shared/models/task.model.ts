import { List } from "./list.model";

export interface Task {
    id: number;
    name: string;
    description: string;
    date: Date;

    listId: number;
    list: List;
}