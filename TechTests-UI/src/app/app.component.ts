import { AfterViewInit, Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth-service/auth.service';
import { Message } from './data/message';
import { MessageService } from './services/message-service/message.service';
import { Constants } from './data/constants';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'TechTests-UI';

  isAuthenticated: boolean = false;

  messages: Message[] = [];

  constructor(private authService: AuthService, private messageService: MessageService) {
    this.authService.isAuthenticated.subscribe(
      next => {
        this.isAuthenticated = next;
      }      
    );

    this.messageService.messageBehaviorSubject.subscribe(
      message => {
        this.messages.push(message);

        setTimeout(() => {
          this.messages.shift();
        }, Constants.messageLifetime + Constants.fastTransition + 500);
      }
    );
  }

  ngOnInit(): void {
    this.authService.isAuthenticatedQuery().subscribe(
      (response: any) => {
        this.isAuthenticated = response.isAuthenticated as boolean;
        this.authService.isAuthenticated.next(this.isAuthenticated);

        console.log(this.isAuthenticated);
      },
      error => {
        this.isAuthenticated = false;
        this.authService.isAuthenticated.next(false);

        let message = new Message();
        message.status = Constants.messageFailed;
        message.title = "Connection";
        message.value = "Connection failed!";
        
        this.messageService.pushMessage(message);
      }
    );  
  }
}
