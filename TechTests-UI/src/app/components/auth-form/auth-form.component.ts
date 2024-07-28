import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthForm } from 'src/app/data/authForm';
import { Constants } from 'src/app/data/constants';
import { Message } from 'src/app/data/message';
import { AuthService } from 'src/app/services/auth-service/auth.service';
import { MessageService } from 'src/app/services/message-service/message.service';

@Component({
  selector: 'app-auth-form',
  templateUrl: './auth-form.component.html',
  styleUrls: ['./auth-form.component.css']
})
export class AuthFormComponent implements OnInit {

  @ViewChild("loginBlock") loginBlock: HTMLElement | any;
  isAvailableLogin: boolean = true;
  isAuthenticated: boolean = true;

  title: string = '';
  link: string = '';

  authForm: AuthForm = new AuthForm();

  constructor(private authService: AuthService, private messageService: MessageService) {
    this.authService.isAuthenticated.subscribe(
      next => this.isAuthenticated = next
    );
  }

  ngOnInit(): void {
    this.title = Constants.loginTitle;
    this.link = Constants.registrationTitle
  }

  action() {
    if (this.title == Constants.loginTitle) {
      this.authService.login(this.authForm).subscribe(
        response => {
          let message: Message = response as Message;
          this.messageService.pushMessage(message);

          this.authService.isAuthenticatedQuery().subscribe(
            (response: any) => {
              console.log(response);
              this.authService.isAuthenticated.next(response.isAuthenticated);
            }
          );
        },
        error => {
          let message: Message = error.error as Message;
          this.messageService.pushMessage(message);
        }
      );
    }

    else if (this.title == Constants.registrationTitle) {
      this.authService.registration(this.authForm).subscribe(
        response => {
          let message: Message = response as Message;
          this.messageService.pushMessage(message);

          this.authService.isAuthenticatedQuery().subscribe(
            (response: any) => {
              console.log(response);
              this.authService.isAuthenticated.next(response.isAuthenticated);
            }
          );
        },
        error => {
          let message: Message = error.error as Message;
          this.messageService.pushMessage(message);
        }
      );
    }
  }

  change() {
    if (this.title == Constants.loginTitle) {
      this.title = Constants.registrationTitle;
      this.link = Constants.loginTitle;
    }
    else if (this.title == Constants.registrationTitle) {
      this.title = Constants.loginTitle;
      this.link = Constants.registrationTitle;
    }
  }

  check() {
    if (this.title == Constants.registrationTitle) {
      this.authService.isAvailableLogin(this.authForm.login).subscribe(
        response => {
          this.isAvailableLogin = response as boolean;
        }
      )
    }
  }
}
