import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectOpoComponent } from './select-opo.component';

describe('SelectOpoComponent', () => {
  let component: SelectOpoComponent;
  let fixture: ComponentFixture<SelectOpoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectOpoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SelectOpoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
