import { Component, OnInit } from '@angular/core';
import { SubCategory, OasService, Category, AdminSubCat } from 'src/app/oas.service';
import { FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-subcategory',
  templateUrl: './subcategory.component.html',
  styleUrls: ['./subcategory.component.css']
})
export class SubcategoryComponent implements OnInit {
  subcategoryList:AdminSubCat[];
  subcategories: SubCategory[]=[];
  categoryData:Category[];
  public Category:number=0;
  subcatModel: SubCategory;
  showNew: Boolean = false;
  submitType: string = 'Save';
  selectedRow: number;
  constructor(private oasService:OasService,private fb: FormBuilder,private http:HttpClient) {
   }

   rootUrl='http://172.27.233.178:802'
   response:string;
  
  ngOnInit() {
    this.oasService.getAllCategory().subscribe(data=>this.categoryData=data);
    this.oasService.getAllSubCategory().subscribe(data=>this.subcategoryList=data); 
    
  };

  OnCategoryCreate()
{ 
  console.log(this.subcategoryList);
}

onNew() {
  this.subcatModel = new SubCategory();
  this.submitType = 'Save';
  this.showNew = true;
}

onSave() {
  if (this.submitType === 'Save') {
    if((this.subcategoryList.filter(x=>x.CategoryName==this.subcatModel.SubCategoryName)).length>0)
    {
      alert("Subategory exists!!");
    }
    else{    
      this.subcatModel.CategoryID=this.Category;
      this.http.post<AdminSubCat[]>(this.rootUrl+'/api/Admin/SubCategory',this.subcatModel).subscribe((data) => this.subcategoryList=data);
    }
   
  } else {
    this.subcatModel.CategoryID=this.Category;
    this.http.put<AdminSubCat[]>(this.rootUrl+'/api/Admin/SubCategory',this.subcatModel).subscribe((data) => this.subcategoryList=data );
    
  }
  this.showNew = false;
}

onEdit(index: number) {
  this.selectedRow = index;
  this.subcatModel = new SubCategory();
  this.subcatModel = Object.assign({}, this.subcategoryList[this.selectedRow]);
  this.submitType = 'Update';
  this.showNew = true;
}

onDelete(index: number) {
  this.http.delete<AdminSubCat[]>(this.rootUrl+'/api/Admin/SubCategory/'+this.subcategoryList[index].SubCategoryID).subscribe((data) => this.subcategoryList=data); 
}

onCancel() {

  this.showNew = false;
}

}
