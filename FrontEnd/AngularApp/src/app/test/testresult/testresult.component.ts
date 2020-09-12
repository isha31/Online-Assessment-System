import { Component, OnInit } from '@angular/core';

import { Params, ActivatedRoute, Router } from '@angular/router';
import { QuizService } from '../quiz.service';
import { Category } from 'src/app/oas.service';


@Component({
  selector: 'app-testresult',
  templateUrl: './testresult.component.html',
  styleUrls: ['./testresult.component.css']
})
export class TestresultComponent implements OnInit {
  
  starttime:Date; 
  endtime:Date; 
  correctans ;  
  unattempted ;  
  wrongans : number ; 
  marks : any  ;
  time;
  CategoryData : Category[];
  constructor(private route: ActivatedRoute, private router: Router, private quizservice : QuizService) { }

  ngOnInit() {
    this.route.queryParams
    .subscribe(params => {
      console.log('Query Params ='+JSON.stringify(params)); // {order: "popular"}
      this.starttime = new Date(params.starttime);
      this.correctans = params.correct;
      this.unattempted =params.unattem;
      this.endtime =new Date(params.endtime);

      console.log('Hours ='+ this.starttime.getHours());

      this.initData()
    });
    
  }
  initData(){
     console.log('init called');
     
     this.time= (this.endtime.getMinutes()) - (this.starttime.getMinutes());
    var temp: number = (parseInt(this.correctans, 10) + (parseInt(this.unattempted, 10))); 
     this.wrongans = (10 - temp); 
     this.marks = this.correctans;

     console.log('time = '+ this.time);
     console.log('wrongands = '+ this.wrongans);
     console.log('amrks = '+ this.marks); 
     
    this.quizservice.postresult(this.marks,this.starttime,this.endtime);

  }

}
