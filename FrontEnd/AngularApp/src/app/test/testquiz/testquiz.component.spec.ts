import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestquizComponent } from './testquiz.component';

describe('TestquizComponent', () => {
  let component: TestquizComponent;
  let fixture: ComponentFixture<TestquizComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestquizComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestquizComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  
});
