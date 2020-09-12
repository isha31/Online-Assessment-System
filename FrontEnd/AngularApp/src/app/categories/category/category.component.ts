import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { CategoryService, category, subcategory, topic } from '../category.service';
import { SubCategory } from 'src/app/oas.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  
  mode : number = 0 ;
  subcatid : number = 0;
  catid : any; 
  test : any; 
  paramsSubscription: any;
  public Category:number =0 ;
  public SubCategory:number = 0;
  public Topic:number = 0; 
  categoryData: category[];
  subcategoryData:subcategory[];
  topicData:topic[];
  SearchKey : string =""; 


  constructor(private route: ActivatedRoute,public categoryservice:CategoryService){ }

  ngOnInit() { 
     this.categoryservice.getCategories().subscribe( 
       (data) => { this.categoryData=data ,
         console.log(this.categoryData)} );
     this.categoryservice.getSubCategories().subscribe( 
        (data) => { this.subcategoryData=data , 
          console.log(this.subcategoryData) 
          });
    this.categoryservice.getSubtopics().subscribe( 
          (data) => { this.topicData=data, 
               console.log(this.topicData);               
           });  


      // Take URL data
      this.route.queryParams
    .subscribe(params => {
           if(params.subid){ 
           this.subcatid = params.subid; 
          }
           console.log("SubCat ID ="+this.subcatid);              
      });  

    // Change Mode.  
    if(this.subcatid>0){
       this.mode = 1; 
       console.log("Model ="+this.mode);
    } 
      
      
    
    
  }

filterSubById(id) {
    return this.subcategoryData.filter(item => item.CategoryID == id);
}
  
filterTopicById(id) {
  return this.topicData.filter(item => item.SubCategoryID == id);
}

filtertestbytopic(id) {
  return this.topicData.filter(item => item.TopicID == id);
}

filtertestbySearch(topic){
  return this.topicData.filter(item => item.TopicName == topic);
}

filtertestbySubtopic(sid){
  return this.topicData.filter(item => item.SubCategoryID == sid);
}

subcategoryoftopic(id){
   var  obj: subcategory[] =  this.subcategoryData.filter(item => item.SubCategoryID == id);
   return obj[0].SubCategoryName;
}



}
