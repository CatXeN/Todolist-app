import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardBoardListComponent } from './dashboard-board-list.component';

describe('DashboardBoardListComponent', () => {
  let component: DashboardBoardListComponent;
  let fixture: ComponentFixture<DashboardBoardListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardBoardListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DashboardBoardListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
