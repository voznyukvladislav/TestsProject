import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AuthForm } from 'src/app/data/authForm';
import { Constants } from 'src/app/data/constants';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isAuthenticated: BehaviorSubject<boolean> = new BehaviorSubject(true);
  
  constructor(private http: HttpClient) { }

  isAuthenticatedQuery() {
    return this.http.get(`${Constants.api}/${Constants.auth}/${Constants.isAuthenticated}`, { withCredentials: true });
  }

  login(authForm: AuthForm) {
    return this.http.post(`${Constants.api}/${Constants.auth}/${Constants.login}`, authForm, { withCredentials: true });
  }

  logout() {
    return this.http.post(`${Constants.api}/${Constants.auth}/${Constants.logout}`, {}, {withCredentials: true});
  }

  registration(authForm: AuthForm) {
    return this.http.post(`${Constants.api}/${Constants.auth}/${Constants.registration}`, authForm, { withCredentials: true });
  }

  isAvailableLogin(login: string) {
    return this.http.get(`${Constants.api}/${Constants.auth}/${Constants.isAvailableLogin}?login=${login}`);
  }
}
