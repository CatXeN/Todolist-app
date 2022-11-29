import { Board } from './board.model';
import { Task } from './task.model';

export interface List {
    id: number;
    name: string;
    order: number;
    tasks: Task[];
    boardId: number;
    board: Board
}