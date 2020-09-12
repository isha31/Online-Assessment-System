import { Component, OnInit } from '@angular/core';
import * as jspdf from 'jspdf';  
import html2canvas from 'html2canvas';  
import * as Chart from 'chart.js';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {

  constructor() { }
colorChangeValue = 30;
dataset:any
chartColors = {
  red: 'rgb(255, 0, 0)',
  blue: 'rgb(54, 162, 235)',
  yellow:'rgb(255,255,0)',
  black:'rgb(0,0,0)',
  white:'rgb(255,255,255)'

};
public captureScreen()  
{  
  var data = document.getElementById('contentToConvert');  
  html2canvas(data).then(canvas => {  
    // Few necessary setting options  
    var imgWidth = 200;   
    var pageHeight = 295;    
    var imgHeight = canvas.height * imgWidth / canvas.width;  
    var heightLeft = imgHeight;  

    const contentDataURL = canvas.toDataURL('image/png')  
    let pdf = new jspdf('p', 'mm', 'a4'); // A4 size page of PDF  
    var position = 0;  
    pdf.addImage(contentDataURL, 'JPG', 0, position, imgWidth, imgHeight)  
    pdf.save('MYPdf.pdf'); // Generated PDF   
  });  
}  

  ngOnInit() {
    var myChart = new Chart(document.getElementById("bar-chart-horizontal"), {
      type: 'horizontalBar',
      data: {
        labels: ["Java", "C++", "Data Structures", "AI", "DataScience"],
        datasets: [
          {
            label: "Population (millions)",
            
            backgroundColor: [ this.chartColors.white,
              this.chartColors.white,
              this.chartColors.white,
              this.chartColors.white],
            data: [25,45,75,95,100]
          }
          
        ]
        
      },
      options: {
        legend: { display: true },
        title: {
          display: true,
          text: 'Predicted world population (millions) in 2050'
        }
      }
  });
  this.dataset = myChart.data.datasets[0];
  for (var i = 0; i < this.dataset.data.length; i++) {
    if (this.dataset.data[i] >0 && this.dataset.data[i] <= 30 ) {
      this.dataset.backgroundColor[i] = this.chartColors.red;
    }
    if (this.dataset.data[i] >30 && this.dataset.data[i] <= 50 ) {
      this.dataset.backgroundColor[i] = this.chartColors.yellow;
    }

    if (this.dataset.data[i] >50 && this.dataset.data[i] <= 80) {
      this.dataset.backgroundColor[i] = this.chartColors.black;
    }
    if (this.dataset.data[i] >90 && this.dataset.data[i] <= 100) {
      this.dataset.backgroundColor[i] = this.chartColors.blue;
    }
  }
  myChart.update();

  }
 //set this to whatever is the deciding color change value


}
