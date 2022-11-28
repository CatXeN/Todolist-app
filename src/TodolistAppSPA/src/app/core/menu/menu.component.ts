import { DashboardService } from './../../modules/dashboard/services/dashboard.service';
import { FlatTreeControl } from '@angular/cdk/tree';
import { Component } from '@angular/core';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';
import { BoardNode } from '../../shared/models/board-node.model';
import { Router } from '@angular/router';

interface ExampleFlatNode {
  expandable: boolean;
  name: string;
  level: number;
}

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent {
  boards: BoardNode[] = [];

  private _transformer = (node: BoardNode, level: number) => {
    return {
      expandable: !!node.children && node.children.length > 0,
      name: node.name,
      level: level,
    };
  };

  treeControl = new FlatTreeControl<ExampleFlatNode>(
    node => node.level,
    node => node.expandable,
  );

  treeFlattener = new MatTreeFlattener(
    this._transformer,
    node => node.level,
    node => node.expandable,
    node => node.children,
  );

  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);

  constructor(private dashboardService: DashboardService, public router: Router) {
    let TREE_DATA: BoardNode[] = [];

    dashboardService.getBoardsNode().subscribe(result => {
      TREE_DATA = [{
        name: 'Projects',
        children: result
      }];

      this.boards = result; 
      this.dataSource.data = TREE_DATA;
    });
  }

  hasChild = (_: number, node: ExampleFlatNode) => node.expandable;

  generateRoute(name: string): string[] {
    const id = this.boards.find(board => board.name === name)?.id;
    return ['project/' + id]
  }
}
