import { Component, OnInit } from '@angular/core';
import { Topic, OasService, SubCategory, AdminTopic } from 'src/app/oas.service';
import { FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-topics',
  templateUrl: './topics.component.html',
  styleUrls: ['./topics.component.css']
})
export class TopicsComponent implements OnInit {
  topicList:AdminTopic[];
  topics: Topic[]=[];
  subcategoryData:SubCategory[];
  public SubCategory:number=0;
  topicModel: Topic;
  showNew: Boolean = false;
  submitType: string = 'Save';
  selectedRow: number;
  constructor(private oasService:OasService,private fb: FormBuilder,private http:HttpClient) {
   }
   rootUrl='http://172.27.233.178:802'
   response:string;
  
  ngOnInit() {
    this.oasService.getAllSubCategory().subscribe(data=>this.subcategoryData=data);
    this.oasService.getAllTopics().subscribe(
      (data)=>{this.topicList=data,
        console.log(this.topicList)
    });  
  };

onNew() {
  this.topicModel = new Topic();
  this.submitType = 'Save';
  this.showNew = true;
}

onSave() {
  if (this.submitType === 'Save') {
    if((this.topicList.filter(x=>x.TopicName==this.topicModel.TopicName)).length>0)
    {
      alert("Topic exists!!");
    }
    else{    
      this.topicModel.SubCategoryID=this.SubCategory;
    this.http.post<AdminTopic[]>(this.rootUrl+'/api/Admin/Topic',this.topicModel).subscribe((data) => this.topicList=data);
    }
    

  } else {
    this.topicModel.SubCategoryID=this.SubCategory;
    console.log("Data:"+" "+this.topicModel.TopicID+" "+this.topicModel.TopicName+" "+this.SubCategory);
     this.http.put<AdminTopic[]>(this.rootUrl+'/api/Admin/Topic',this.topicModel).subscribe((data) => this.topicList=data );

    }
  this.showNew = false;
}

onEdit(index: number) {
  this.selectedRow = index;
  this.topicModel = new Topic();
  this.topicModel = Object.assign({}, this.topicList[this.selectedRow]);
  this.submitType = 'Update';
  this.showNew = true;
}

onDelete(index: number) {
  this.http.delete<AdminTopic[]>(this.rootUrl+'/api/Admin/Topic/'+this.topicList[index].TopicID).subscribe((data) => this.topicList=data);

}

onCancel() {
  this.showNew = false;
}

}
