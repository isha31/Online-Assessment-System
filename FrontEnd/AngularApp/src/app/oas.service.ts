import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { RequestOptions } from '@angular/http';
import { Time } from '@angular/common';


@Injectable({
  providedIn: 'root'
})
export class OasService {

  constructor(private http:HttpClient) { }

  rootUrl='http://172.27.233.178:802';
  url='http://172.27.232.244:803';
  
  getAllCategory():Observable <Category[]>{
      return this.http.get<Category[]>(this.rootUrl+'/api/Admin/Category');
   }
// createCategory():Observable<Category>
// {
//   return this.http.post<Category>(this.rootUrl+'/api/Category');
// }

   getAllSubCategory():Observable <AdminSubCat[]>{
    return this.http.get<AdminSubCat[]>(this.rootUrl+'/api/Admin/AdminSubCategory');
 }
  
 getAllTopics():Observable <AdminTopic[]>{
  return this.http.get<AdminTopic[]>(this.rootUrl+'/api/Admin/AdminTopic');
}

getOverallScore():Observable <OverallScore[]>{
  var t= localStorage.getItem('user');
  return this.http.get<OverallScore[]>(this.rootUrl+'/api/Admin/Report/CategoryReport/1?id='+t);
}

getCompScore():Observable <CompScore[]>{
  var t= localStorage.getItem('user');
  return this.http.get<CompScore[]>(this.rootUrl+'/api/Admin/Report/SubCategoryReport/1?id='+t);
}

getUserLog():Observable <UserLog>{
  var t= localStorage.getItem('user');
  return this.http.get<UserLog>(this.rootUrl+'/api/User/UserTestLog/1?email='+t);
}

fetchTopicScoreObservable():Observable<TopicScore[]>{
  var t= localStorage.getItem('user');
  return this.http.get<TopicScore[]>(this.rootUrl+'/api/Admin/Report/TopicReport/1?id='+t);
}

fetchUsersObservable():Observable <User[]>{
  var t= localStorage.getItem('user');
  return this.http.get<User[]>(this.rootUrl+'/api/Admin/User/1?email='+t);
}

   postFile(fileToUpload:File)
   {
    const endpoint = this.rootUrl+'/api/Admin/QuestionBank';
    const formData:FormData=new FormData();
    formData.append('Excel',fileToUpload,fileToUpload.name);
    console.log(formData);
    return this.http.post(endpoint,formData);
   }
}

export class Category{
  CategoryID:number;
  CategoryName:string;
}
export class User{
  FirstName:string;
  LastName:string;
  EmailId:string;
  Gender:string;
  DOB:Date;
  Country:string;
  ContactNo:string;
}
export class SubCategory{
  SubCategoryID:number;
  SubCategoryName:string;
  CategoryID:number;
}

export class AdminSubCat{
  SubCategoryID:number;
  SubCategoryName:string;
  CategoryID:number;
  CategoryName:string;
}

export class Topic{
  TopicID:number;
  TopicName:string;
  SubCategoryID:number;
}

export class AdminTopic{
  TopicID:number;
  TopicName:string;
  SubCategoryID:number;
  SubCategoryName:string;
}

export class OverallScore{
  MarksObtained:any;
  CategoryName: string;
}

export class CompScore{
  MarksObtained:any;
  SubCategoryName:any;
}

export class TopicScore{
  MarksObtained:any;
  TopicName:any;
}

export class UserLog{
  TopicName:string;
  TestDate:any;
  StartTime:any;
  EndTime:any;
  MarksObtained:any;
}
