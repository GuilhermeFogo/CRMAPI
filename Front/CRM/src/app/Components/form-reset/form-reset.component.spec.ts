import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormResetComponent } from './form-reset.component';

describe('FormResetComponent', () => {
  let component: FormResetComponent;
  let fixture: ComponentFixture<FormResetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormResetComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormResetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
