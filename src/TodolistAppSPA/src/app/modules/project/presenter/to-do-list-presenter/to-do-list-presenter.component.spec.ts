import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToDoListPresenterComponent } from './to-do-list-presenter.component';

describe('ToDoListPresenterComponent', () => {
  let component: ToDoListPresenterComponent;
  let fixture: ComponentFixture<ToDoListPresenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToDoListPresenterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ToDoListPresenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
