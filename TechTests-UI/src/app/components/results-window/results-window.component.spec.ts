import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResultsWindowComponent } from './results-window.component';

describe('ResultsWindowComponent', () => {
  let component: ResultsWindowComponent;
  let fixture: ComponentFixture<ResultsWindowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResultsWindowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ResultsWindowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
