import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GerenciaUserComponent } from './gerencia-user.component';

describe('GerenciaUserComponent', () => {
  let component: GerenciaUserComponent;
  let fixture: ComponentFixture<GerenciaUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GerenciaUserComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GerenciaUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
