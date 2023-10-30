import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DefinePassComponent } from './define-pass.component';

describe('DefinePassComponent', () => {
  let component: DefinePassComponent;
  let fixture: ComponentFixture<DefinePassComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DefinePassComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DefinePassComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
