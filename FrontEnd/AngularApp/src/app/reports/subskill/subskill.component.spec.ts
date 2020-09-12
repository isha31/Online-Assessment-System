import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SubskillComponent } from './subskill.component';

describe('SubskillComponent', () => {
  let component: SubskillComponent;
  let fixture: ComponentFixture<SubskillComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SubskillComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubskillComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  
});
