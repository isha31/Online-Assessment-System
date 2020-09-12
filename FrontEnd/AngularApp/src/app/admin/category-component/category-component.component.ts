import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Category,OasService } from 'src/app/oas.service';



@Component({
  selector: 'app-category-component',
  templateUrl: './category-component.component.html',
  styleUrls: ['./category-component.component.css']
})
export class CategoryComponentComponent implements OnInit {
  categoryList:Category[];
  categories: Category[]=[];

  catModel: Category;
  showNew: Boolean = false;
  submitType: string = 'Save';
  selectedRow: number;
  constructor(private oasService:OasService,private fb: FormBuilder,private http:HttpClient) {

   }
   rootUrl='http://172.27.233.178:802';
   response:string;
  
  ngOnInit() {
    this.oasService.getAllCategory().subscribe(data=>this.categoryList=data);  
  };

  OnCategoryCreate()
{ 
  console.log(this.categoryList);
}

onNew() {
  this.catModel = new Category();
  this.submitType = 'Save';
  this.showNew = true;
}

onSave() {
  if (this.submitType === 'Save') {
    if((this.categoryList.filter(x=>x.CategoryName==this.catModel.CategoryName)).length)
    {
      alert("Category exists!!");
    }
    else{    
      this.http.post<Category>(this.rootUrl+'/api/Admin/Category',this.catModel).subscribe((data) =>{ var cat = { CategoryID : data.CategoryID, CategoryName : data.CategoryName }; this.categoryList.push(cat) } );
    
    }
  } else {
     this.http.put<Category[]>(this.rootUrl+'/api/Admin/Category',this.catModel).subscribe(data => this.categoryList=data);     //window.location.reload();
    }
this.showNew = false;

}

onEdit(index: number) {

  this.selectedRow = index;
  this.catModel = new Category();
  this.catModel = Object.assign({}, this.categoryList[this.selectedRow]);
  this.submitType = 'Update';
  this.showNew = true;
}

onDelete(index: number) {
  this.http.delete<Category[]>(this.rootUrl+'/api/Admin/Category/'+this.categoryList[index].CategoryID).subscribe((data) => this.categoryList=data );
  
}

onCancel() {
  this.showNew = false;
}

refreshcategory(){
  this.oasService.getAllCategory().subscribe(data=>{this.categoryList=data;console.log(data)}); 

}

}
