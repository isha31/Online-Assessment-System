import { Component, OnInit } from '@angular/core';
import { CategoryService, category, subcategory } from '../category.service';
import { ActivatedRoute, Params } from '@angular/router';
import { SubCategory, OasService } from '../../oas.service';

@Component({
  selector: 'app-filtersubcategory',
  templateUrl: './filtersubcategory.component.html',
  styleUrls: ['./filtersubcategory.component.css']
})
export class FiltersubcategoryComponent implements OnInit {

  catid : any; 
  paramsSubscription: any;
  subcategoryData:subcategory[];
  constructor(private route: ActivatedRoute,public categoryservice:CategoryService) { }

  ngOnInit() {
    
    this.categoryservice.getSubCategories().subscribe( 
      (data) => { this.subcategoryData=data , 
        console.log(this.subcategoryData) 
    });

    // Getting url data
    this.catid= this.route.snapshot.params['id'];
    this.paramsSubscription = this.route.params
    .subscribe(
       (params: Params) => {
          this.catid = params['id'] }
       );
  }

  subbycategory(){
    return this.subcategoryData.filter(item => item.CategoryID == this.catid);
  }

}
