import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { CookieService } from './../cookie/cookie.service';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GuardService implements CanActivate {
  private cooke: CookieService
  private Router: Router
  constructor(cookie: CookieService, Router: Router) {
    this.cooke = cookie
    this.Router = Router;
  }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    const verdade = this.cooke.ExistCookie('Session');
    if (verdade) {
      return true;
    } else {
      this.Router.navigateByUrl('');
      return false;
    }
  }
}
