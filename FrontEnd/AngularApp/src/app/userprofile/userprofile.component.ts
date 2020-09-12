import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpErrorResponse } from '@angular/common/http';
import { User, OasService, OverallScore, UserLog } from 'src/app/oas.service';

@Component({
  selector: 'app-userprofile',
  templateUrl: './userprofile.component.html',
  styleUrls: ['./userprofile.component.css']
})
export class UserprofileComponent implements OnInit {
  label:any=[]
  weakness:any=[]
userData:User[];
userLog:UserLog;
  constructor (private httpService: HttpClient,private list:OasService) { }
  overallData:OverallScore[]
  score: any=[0];
  colour:any=[];
pieChartOptions = {  
  responsive: true,
}

pieChartLabels =  [];

// CHART COLOR.
pieChartColor:any = [
  {
      backgroundColor: [
      ]
  }
]

pieChartData:any = [
  { 
    data:[]  
  }
];
  
  ngOnInit () {
    this.list.fetchUsersObservable().subscribe(data=>this.userData=data);
    this.list.getUserLog().subscribe(data=>this.userLog=data);



    this.list.getOverallScore()
    .subscribe(
        data => {
          for (let i in data) {
            this.score[i]=data[i].MarksObtained
            this.pieChartLabels[i]=data[i].CategoryName;
          }
          this.pieChartData = [ { "data" : this.score} ]
          for(let i in this.score){
            if(this.score[i]>=0 && this.score[i]<15)
            {
              this.colour[i]="#E27D60"
            }
            if(this.score[i]>=15 && this.score[i]<50)
            {
              this.colour[i]="#F8E9A1"
            }
            if(this.score[i]>=50 && this.score[i]<80)
            {
              this.colour[i]="#41B3A3"
            }
            if(this.score[i]>=80 && this.score[i]>=100)
            {
              this.colour[i]="#659DBD"
            }
      }
          },
      
    );

    for(let i in this.pieChartData ){
      this.pieChartColor = [ { "backgroundColor" : this.colour} ]
      
    }
    this.list.fetchTopicScoreObservable()
    .subscribe(
        data => {
          for (let i in data) {
           if(data[i].MarksObtained>15)
           {
             this.label[i]=data[i].TopicName
             
           }
           if(data[i].MarksObtained<5)
           {
             this.weakness[i]=data[i].TopicName

           }
          }
          
      

          },
      
    );

}

onChartClick(event) {
  console.log(event);
}

}
