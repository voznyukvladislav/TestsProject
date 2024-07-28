import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Type5formComponent } from './type5form.component';

describe('Type5formComponent', () => {
  let component: Type5formComponent;
  let fixture: ComponentFixture<Type5formComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Type5formComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Type5formComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
