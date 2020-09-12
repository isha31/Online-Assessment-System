import { Injectable } from '@angular/core';
declare var toastr:any; 
@Injectable({
  providedIn: 'root'
})
export class ToastrService {

  constructor() { }
  
  Success( title:String, message ?: String){
    toastr.success(message,title);
  }
  Error( title:String, message ?: String){
    toastr.error(message,title);
  }
}
