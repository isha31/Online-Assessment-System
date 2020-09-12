import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  constructor(private router : Router){}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    if(localStorage.getItem('user') == 'johnadmin@gmail.com'){
      console.log('Admin Guard = Admin');     
      return true;
    }else{
       console.log('Admin Guard = User');
       this.router.navigate(['/accessdenied']);
       return false;
    }
  }
}
