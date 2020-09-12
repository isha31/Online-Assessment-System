import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormArray, FormControl, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { AuthService } from '../auth.service';
import { ToastrService } from 'src/app/toastr.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  isSubmitted :false;
  signupForm: FormGroup;
  genders = ['male', 'female'];

  constructor(private fb: FormBuilder,private router: Router,
    private auth:AuthService,private toast:ToastrService) { }

  ngOnInit() { 
     this.signupForm = this.fb.group({
      email: ['',[Validators.required, Validators.email]],
      fname : ['',[Validators.required]],
      lname : ['',[Validators.required]],
      contactnumber : ['',[Validators.required,Validators.minLength(6)]],
      dob : ['',[Validators.required]],
      gender : ['',[Validators.required]], 
      password : ['',[Validators.required,Validators.pattern("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")] ],
      confirmPassword : ['',Validators.required],
      country : ['',Validators.required]

     },{validator:  this.PasswordValidator});
  }
  
  onSubmit(){
    console.log(this.signupForm);
    if(this.signupForm.status!='VALID'){
      this.toast.Error('Error', 'Invalid Form');
    }else{
     
     const data={
        'Email' : this.signupForm.get('email').value,
         'Password' : this.signupForm.get('password').value,
         'ConfirmPassword' : this.signupForm.get('confirmPassword').value,
         'Gender' : this.signupForm.get('gender').value,
         'ContactNo' : this.signupForm.get('contactnumber').value,
         'Country' : this.signupForm.get('country').value,
         'FirstName' : this.signupForm.get('fname').value,
         'LastName' : this.signupForm.get('lname').value,
          'DOB' : this.signupForm.get('dob').value
      }; 
      this.auth.registeruser(data)
      .subscribe(
        (Response) => { this.toast.Success('Success'), 
        this.router.navigate(['/']);
        },
        (err) => { this.toast.Error('Error','Backend error') }
      ) ;
    }   
  } 

   PasswordValidator (control : AbstractControl) : {[key:string] : boolean} | null {
        console.log('ps valid called');
         
        const p= control.get('password'); 
        const cp=control.get('confirmPassword');
        return p && cp && p.value != cp.value ? { misMatch : true} : null;
  }



}
