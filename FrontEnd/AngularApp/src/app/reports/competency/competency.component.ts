import { Component, OnInit } from '@angular/core';
import { CompScore, OasService, TopicScore } from 'src/app/oas.service';
import * as Chart from 'chart.js';


@Component({
  selector: 'app-competency',
  templateUrl: './competency.component.html',
  styleUrls: ['./competency.component.css']
})
export class CompetencyComponent implements OnInit {
  subCatData:CompScore[]
  score: any=[0];
  colour:any=[];
constructor(private httpService: OasService) { }
pieChartOptions = {
  
  responsive: true,
  scales: {
      yAxes: [{
        barPercentage:0.3,
        categoryPercentage: 1.8,
          ticks: {
              beginAtZero: true,
              
          }
      }],
      xAxes: [{
          // Change here
          barPercentage: 0.2,
          ticks: {
              beginAtZero: true
          }
      }]
  }
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
 
  this.httpService.getCompScore()
    .subscribe(
        data => {
          for (let i in data) {
            this.score[i]=data[i].MarksObtained
            this.pieChartLabels[i]=data[i].SubCategoryName;
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

      // this.pieChartColor = [ { "backgroundColor" : this.colour} ]
          },
      
    );

    for(let i in this.pieChartData ){
      this.pieChartColor = [ { "backgroundColor" : this.colour} ]
      
    }

}

onChartClick(event) {
  console.log(event);
}

}