import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  
  rootUrl= 'http://172.27.233.178:802'; 
  constructor(public http: HttpClient) { } 

  getCategories():Observable<category[]>{
     console.log('get cat called');
     
     return this.http.get<category[]>(this.rootUrl+'/api/Admin/Category');
     
  } 

  getSubCategories(){
    console.log('get Subcat called');  
    return this.http.get<subcategory[]>(this.rootUrl+'/api/Admin/SubCategory');    
  }
  
  getSubtopics(){
    console.log('get Subtop called');
    return this.http.get<topic[]>(this.rootUrl+'/api/Admin/Topic');   
  }

 

}

export class category{
   CategoryID :number;
   CategoryName: string;  
}

export class subcategory{
   SubCategoryID : number;
   SubCategoryName: string;
   CategoryID : number; 
}

export class topic {
  SubCategoryID :number;
  TopicID : number; 
  TopicName : string;
}
