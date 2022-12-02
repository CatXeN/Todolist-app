import { Component } from '@angular/core';

@Component({
  selector: 'app-user-assigned',
  templateUrl: './user-assigned.component.html',
  styleUrls: ['./user-assigned.component.scss']
})
export class UserAssignedComponent {
  displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  dataSource = ELEMENT_DATA;
}
