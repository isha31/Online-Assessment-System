import { Component, OnInit } from '@angular/core';
import { AuthService } from '../Auth/auth.service';
import { Router } from '@angular/router';
import { ToastrService } from '../toastr.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private auth : AuthService, private router : Router,private toast: ToastrService) { } 
   
 

  ngOnInit() {
    var adminUser="johnadmin@gmail.com";
  }

  get user(): any {
    return localStorage.getItem('user');
  } 
  
  logout(){
     this.auth.logout();
     this.toast.Success('Logout Success');
     this.router.navigate(['/']);
  }

}
