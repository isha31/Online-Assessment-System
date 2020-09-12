import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryComponentComponent } from './category-component.component';

describe('CategoryComponentComponent', () => {
  let component: CategoryComponentComponent;
  let fixture: ComponentFixture<CategoryComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CategoryComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

 
});
