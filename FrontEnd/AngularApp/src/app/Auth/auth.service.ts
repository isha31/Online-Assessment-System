import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  // Comment TEst
  url = 'http://172.27.233.178:802'; 
  constructor(private http:HttpClient) { } 

  registeruser(data:any){
       console.log('auth register called');
       return this.http.post(this.url+'/api/Account/Register',data);
  }

  userAuthentication(userName, password):any {
    console.log('Serivce auth');
    
    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded' });
    return this.http.post(this.url + '/token', data, { headers: reqHeader });
  }

  logout(){
     localStorage.clear();
  }
  
}
