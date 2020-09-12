import { Component, OnInit } from '@angular/core';
import { TopicScore, OasService } from 'src/app/oas.service';



@Component({
  selector: 'app-subskill',
  templateUrl: './subskill.component.html',
  styleUrls: ['./subskill.component.css']
})
export class SubskillComponent implements OnInit {

  topicData:TopicScore[]

    score:any=[0];
    colour:any=[0];
  constructor(private httpService: OasService) { }
  pieChartOptions = {
    
    responsive: true,
    scales: {
        yAxes: [{
            barPercentage:0.3,
        categoryPercentage: 1.8,
            ticks: {
                beginAtZero: true  
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

pieChartLabels:any =  [this.topicData,this.topicData];

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


    this.httpService.fetchTopicScoreObservable()
    .subscribe(
        data => {
          for (let i in data) {
            this.score[i]=data[i].MarksObtained
            this.pieChartLabels[i]=data[i].TopicName;
          }
          for(let i in this.score){
            if(this.score[i]>0 && this.score[i]<30)
            {
              this.colour[i]="#E27D60"
            }
            if(this.score[i]>=30 && this.score[i]<50)
            {
              this.colour[i]="#F8E9A1"
            }
            if(this.score[i]>=50 && this.score[i]<80)
            {
              this.colour[i]="#41B3A3"
            }
            if(this.score[i]>=80 && this.score[i]<=100)
            {
              this.colour[i]="#659DBD"
            }
      }

          this.pieChartData = [ { "data" : this.score} ]

       //   this.pieChartColor = [ { "backgroundColor" : this.colour} ]
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
