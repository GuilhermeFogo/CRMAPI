import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormOpoComponent } from './form-opo.component';

describe('FormOpoComponent', () => {
  let component: FormOpoComponent;
  let fixture: ComponentFixture<FormOpoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormOpoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormOpoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
