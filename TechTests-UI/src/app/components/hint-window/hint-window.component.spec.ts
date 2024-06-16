import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HintWindowComponent } from './hint-window.component';

describe('HintWindowComponent', () => {
  let component: HintWindowComponent;
  let fixture: ComponentFixture<HintWindowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HintWindowComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HintWindowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
