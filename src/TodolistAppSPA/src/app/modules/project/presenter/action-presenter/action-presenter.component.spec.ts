import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActionPresenterComponent } from './action-presenter.component';

describe('ActionPresenterComponent', () => {
  let component: ActionPresenterComponent;
  let fixture: ComponentFixture<ActionPresenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActionPresenterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ActionPresenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
