import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Type4formComponent } from './type4form.component';

describe('Type4formComponent', () => {
  let component: Type4formComponent;
  let fixture: ComponentFixture<Type4formComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Type4formComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Type4formComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
