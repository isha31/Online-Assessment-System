import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Tabset } from './tabset.component';

describe('TabsetComponent', () => {
  let component: Tabset;
  let fixture: ComponentFixture<Tabset>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Tabset ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Tabset);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  
});
