import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FiltersubcategoryComponent } from './filtersubcategory.component';

describe('FiltersubcategoryComponent', () => {
  let component: FiltersubcategoryComponent;
  let fixture: ComponentFixture<FiltersubcategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FiltersubcategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FiltersubcategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  
});
