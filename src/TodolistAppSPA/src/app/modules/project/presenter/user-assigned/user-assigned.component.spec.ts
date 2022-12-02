import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserAssignedComponent } from './user-assigned.component';

describe('UserAssignedComponent', () => {
  let component: UserAssignedComponent;
  let fixture: ComponentFixture<UserAssignedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserAssignedComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserAssignedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
