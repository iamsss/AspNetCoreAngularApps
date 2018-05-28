import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VechileFormComponent } from './vechile-form.component';

describe('VechileFormComponent', () => {
  let component: VechileFormComponent;
  let fixture: ComponentFixture<VechileFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VechileFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VechileFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
