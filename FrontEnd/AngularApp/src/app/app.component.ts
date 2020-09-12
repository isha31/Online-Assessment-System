import { Component } from '@angular/core';
import { HttpClient } from 'selenium-webdriver/http';
import { ToastrService } from './toastr.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AnuglarApp';
  
  constructor(private t: ToastrService){}

  myclick(){
    this.t.Success('Title','My Message from');
  }
}
