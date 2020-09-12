import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormArray, FormControl, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { AuthService } from '../auth.service';
import { ToastrService } from 'src/app/toastr.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
  
  signinForm: FormGroup;
  constructor(private fb: FormBuilder,
    private auth:AuthService,private toast:ToastrService,
    private route: ActivatedRoute,
    private router: Router,) { }

  ngOnInit() { 
    this.signinForm = this.fb.group({
     email: ['',[Validators.required, Validators.email]],
     password : ['',[Validators.required]],     
    });
 }

 onSubmit(){
   console.log(this.signinForm);
   if(this.signinForm.status!='VALID'){
    this.toast.Error('Error', 'Invalid Form');
  }else{     
   
      const username = this.signinForm.get('email').value;
      const password = this.signinForm.get('password').value;
       
  
    this.auth.userAuthentication(username,password)
    .subscribe(
      (data) => {
          console.log(data);
          localStorage.setItem('userToken',data.access_token);
          localStorage.setItem('user',data.userName);
          if(data.Role == 'Admin'){
             console.log('Admin logges');
             this.router.navigate(['/admin']);
             
          }else{ 
            console.log('User Looged');
            // this.router.navigate(['/']);
            window.history.go(-1);
          }  
          this.toast.Success('Success Login') 
      }, 
      (err) => { this.toast.Error('Error','Please check your credentials'); }
    ) ;
  }   
   
 }

}
