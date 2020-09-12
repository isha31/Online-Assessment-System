import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CategoryService, category } from '../categories/category.service';
declare var jquery:any;
declare var $ :any;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  
  categoryData: category[];
  constructor(private router: Router,public categoryservice:CategoryService) { }

  ngOnInit() {
     this.categoryservice.getCategories()
       .subscribe((data) => { this.categoryData=data ,
        console.log('Category Data :'+this.categoryData)});

        $('.carousel').carousel({
          interval: 1000
        })
  }

  onNavigate(){
    this.router.navigate(['/test/results'], { queryParams: { order : 'popular', 'price-range': 'not-cheap' } });
  }

}
