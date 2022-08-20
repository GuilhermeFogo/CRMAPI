import { CookieService } from './../cookie/cookie.service';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginBlockService implements CanActivate {
  private cookie: CookieService;
  private Router: Router;
  constructor(cookie: CookieService, Router: Router) {
    this.Router = Router;
    this.cookie = cookie;
   }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    if(this.cookie.ExistCookie("Session")){
      this.Router.navigateByUrl('/DashBoard');
      return false;
    } else{

      return true;
    }
  }
}
