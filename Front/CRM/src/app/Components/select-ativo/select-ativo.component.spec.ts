import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectAtivoComponent } from './select-ativo.component';

describe('SelectAtivoComponent', () => {
  let component: SelectAtivoComponent;
  let fixture: ComponentFixture<SelectAtivoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectAtivoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectAtivoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
