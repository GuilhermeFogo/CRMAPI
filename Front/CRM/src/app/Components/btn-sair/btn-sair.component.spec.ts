import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BtnSairComponent } from './btn-sair.component';

describe('BtnSairComponent', () => {
  let component: BtnSairComponent;
  let fixture: ComponentFixture<BtnSairComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BtnSairComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BtnSairComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
