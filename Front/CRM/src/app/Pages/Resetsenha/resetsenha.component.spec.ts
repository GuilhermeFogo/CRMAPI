import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResetsenhaComponent } from './resetsenha.component';

describe('ResetsenhaComponent', () => {
  let component: ResetsenhaComponent;
  let fixture: ComponentFixture<ResetsenhaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResetsenhaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ResetsenhaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
