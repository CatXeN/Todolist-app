import { ProjectService } from './../../services/project.service';
import { Board } from './../../../../shared/models/board.model';
import { Component, Input } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { tap } from 'rxjs';

@Component({
  selector: 'app-project-container',
  templateUrl: './project-container.component.html',
  styleUrls: ['./project-container.component.scss']
})
export class ProjectContainerComponent {
  selectedBoard: Board;
  message:string = '';

  constructor(projectService: ProjectService, private route: ActivatedRoute) {
    this.selectedBoard = { id: 0, name: ''}

    this.route.paramMap.subscribe( paramMap => {
      const id = paramMap.get('id');

      if (id) {
        projectService.getBoard(Number(id)).subscribe(result => {
          this.selectedBoard = result;
        })
      }
    })
  }

  receiveMessage($event: string) {
    this.message = $event;
  }
}
