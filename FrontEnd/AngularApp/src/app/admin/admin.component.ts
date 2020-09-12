import { Component, OnInit } from '@angular/core';
import { Category, OasService, SubCategory, Topic } from '../oas.service';
import { HttpResponse, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
  providers:[OasService]
})
export class AdminComponent implements OnInit {
  categoryData:Category[]
  subcategoryData:SubCategory[]
  topicData:Topic[]
  public Category:number;
public SubCategory:number;
public Topic:number =0; 
  selectedFiles: FileList;
  currentFileUpload: File;
  rootUrl='http://172.27.233.178:802';
  constructor(private oasService:OasService,private http:HttpClient) { }

  filterSubById(id) {
    return this.subcategoryData.filter(item => item.CategoryID == id);
}
  
filterTopicById(id) {
  return this.topicData.filter(item => item.SubCategoryID == id);
}
  ngOnInit() {
    this.oasService.getAllCategory().subscribe(data=>this.categoryData=data);
    this.oasService.getAllSubCategory().subscribe(data=>this.subcategoryData=data);
    this.oasService.getAllTopics().subscribe(data=>this.topicData=data);
  }

  selectFile(event) {
    this.selectedFiles = event.target.files;
  }

  OnSubmit()
  {  
    console.log("Topic ID="+this.Topic);
     
    this.currentFileUpload = this.selectedFiles.item(0);
   console.log(this.currentFileUpload);

   const endpoint = this.rootUrl+'/api/Admin/QuestionBank';
   const formData:FormData=new FormData();
   formData.append('Excel',this.currentFileUpload,this.currentFileUpload.name);
   console.log(formData);
  this.http.post(endpoint+"/"+this.Topic,formData).subscribe((result) => {
    console.log("result ="+result);
    if(result=="OK")
  {
    alert("Question bank uploaded successfully!");
  }
  else{
    alert("Error uploading question bank!")
  }
    
       
        });

     this.selectedFiles = undefined;
     
  }



}
