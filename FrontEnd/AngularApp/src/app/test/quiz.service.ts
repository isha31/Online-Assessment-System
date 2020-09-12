import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class QuizService {
  
  rootURL = 'http://172.27.233.178:802';  
  // /api/user/testgenerate/questions/1
  constructor(private http:HttpClient) { } 

  getQuestions(d : any) : any{
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post(this.rootURL+'/api/user/testgenerate/questions/1',d,{headers: reqHeader}) 
  } 

  postresult(cor: any, st: any, endt: any){
     console.log("Post result called"); 
     const dataobj ={
        'UserEmail' : localStorage.getItem('user'),
        'CorrectAnswers' :  cor,
        'IncorrectAnswers' : (10-cor),
         'MarksObtained' : cor,
         'StartTime' : st,
         'EndTime' :   endt
     }
     var reqHeader = new HttpHeaders({ 'Content-Type': 'application/json' });
     this.http.post(this.rootURL+'/api/User/TestGenerate/Test/1',dataobj,{headers: reqHeader})
     .subscribe((data) => {console.log(data);
     });
     
  }

  
}

export interface Iquestions {
    question : string; 
    options : any []; 
    answer : string; 
}
