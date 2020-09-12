import { Component, OnInit } from '@angular/core';
import { QuizService, Iquestions } from '../quiz.service';
import { Params, ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-testquiz',
  templateUrl: './testquiz.component.html',
  styleUrls: ['./testquiz.component.css']
})
export class TestquizComponent implements OnInit {
  
  topid; 
  diffid; 
  paramsSubscription; 
  starttime : any;
  endtime : any;
  quescntr : number = 0;
  correctans : number =0;
  unattempted : number = 0;
  title = 'testquizz'; 
  seconds =300; 
  interval ; 
  questionsdata : any [];
  questions :Array<Iquestions> = new Array<Iquestions>();
  selectedoptions : Array<number> = new Array();
  countdown = 300;
  
  constructor(private quizservice : QuizService,private route: ActivatedRoute, private router: Router) {
     for (let index = 0; index < 10; index++) {
         this.selectedoptions.push(0);
     }
       
       

      

      
  }

  ngOnInit() {
    this.startTimer(); 
    
    this.topid= this.route.snapshot.params['id'];
      this.paramsSubscription = this.route.params
              .subscribe(
                (params: Params) => {
                    this.topid = params['id'], console.log('Topic Id:'+this.topid);
              });

             this.route.queryParams
             .subscribe(params => {
               console.log(params); // {order: "popular"}
       
               this.diffid = params.Difficulty;
               console.log('Difficulty ID : '+this.diffid); // popular
             });

             var data = { 
              'dfid' : this.diffid,
               'topicid' : this.topid
            }
            this.quizservice.getQuestions(data)
            .subscribe( (data) => { this.questionsdata = data ,
               this.transformdata();
             });
    }      
     
  

  transformdata(){
     console.log('Transform Called');
     
     console.log((this.questionsdata)); 
     for (const key in this.questionsdata) {
         console.log(this.questionsdata[key]);
         var ques= (this.questionsdata[key]).Question;
         var ops= [ {'option' : (this.questionsdata[key]).Option1},
         {'option' : (this.questionsdata[key]).Option2},
         {'option' : (this.questionsdata[key]).Option3},
         {'option' : (this.questionsdata[key]).Option4},
        ];
        var ans= (this.questionsdata[key]).Answer;
        var an= ans[ans.length - 1];
        var q ={ 
          'question' : ques,
          'options' :  ops,
          'answer' : an
        }
        this.questions.push(q);
     }
     console.log('Questions are as ');
     console.log(this.questions);
     this.starttime = new Date();
      
  }

  startTimer() {
    this.interval = setInterval(() => {
        if(this.seconds < 1){
          alert("time Up Submit"); 
         //call Submit test Method
          this.onSubmit();
          
       }
      this.seconds--;
    }, 1000);
  }

  displaytime(){
    return ( Math.floor(this.seconds / 60) + ':' + Math.floor(this.seconds % 60)).toString();
  }

  onNext(){
    if(this.quescntr<9){
    this.quescntr++;
    }
  }
  onPrev(){
    if(this.quescntr>0){
    this.quescntr--;
    }
  }

  onClick(i){ 
      this.selectedoptions[this.quescntr] = i+1;    
  } 

  onSubmit(){
    
    // compute correct anwwer
    for (let index = 0; index < 10; index++) {
      var cor=this.questions[index].answer;
       if (this.selectedoptions[index] == parseInt(cor, 10)){
          this.correctans++;
       }
       if (this.selectedoptions[index] == 0){
        this.unattempted++;
       }      
    }
    this.endtime =new Date(); 
    clearInterval(this.interval);
    this.router.navigate(['/test/results'], { queryParams: { starttime : this.starttime, 'endtime': this.endtime, 'correct' : this.correctans, 'unattem' : this.unattempted } });
     
  }

}
