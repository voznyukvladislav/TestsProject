import { Component, OnInit, ViewChild } from '@angular/core';
import { AnsweredQuestion } from 'src/app/data/answeredQuestion';
import { FactoryDTO } from 'src/app/data/factoryDTO';
import { Message } from 'src/app/data/message';
import { Result } from 'src/app/data/result';
import { ResultShort } from 'src/app/data/resultShort';
import { AuthService } from 'src/app/services/auth-service/auth.service';
import { ChatService } from 'src/app/services/chat-service/chat.service';
import { HintService } from 'src/app/services/hint-service/hint.service';
import { MessageService } from 'src/app/services/message-service/message.service';
import { OpenaiApiService } from 'src/app/services/openai-api-service/openai-api.service';
import { ResultService } from 'src/app/services/result-service/result.service';
import { TestService } from 'src/app/services/test-service/test.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  @ViewChild("testButton") testButton: HTMLElement | any;

  isAuthenticated: boolean = false;

  startTestTitle: string = "Start test";
  finishTestTitle: string = "Finish test";

  selectedTestId: number = 0;

  isStartTest: boolean = true;
  isFinishTest: boolean = false;

  isTestOpened: boolean = false;
  endTest: boolean = false;

  questions: any[] = [];

  constructor(
    public testService: TestService,
    public hintService: HintService,
    public resultService: ResultService,
    public chatService: ChatService,
    private authService: AuthService,
    private messageService: MessageService
    ) {
    this.testService.questions.subscribe(q => this.questions = q);
    
    this.testService.isOpened.subscribe(isOpened => { 
      this.isTestOpened = isOpened;
    });

    this.testService.selectedTestId.subscribe(id => this.selectedTestId = id);

    this.authService.isAuthenticated.subscribe(isAuthenticated => this.isAuthenticated = isAuthenticated);
  }

  results() {
    this.resultService.getResults().subscribe(
      results => {
        let shortResults: ResultShort[] = results as ResultShort[];
        this.resultService.shortResults.next(shortResults);

        this.resultService.isOpenedResultsWindow.next(true);

        console.log(shortResults);
      },
      error => {
        let message: Message = error.error as Message;
        this.messageService.pushMessage(message);
      }
    )
  }

  startTest() {
    this.testService.isTestSelectionWindowOpened.next(true);
  }

  finishTest() {
    let confirmation = confirm("Do you want to finish test?");
    if (confirmation == false) return;

    console.log(this.questions);
    let answeredQuestions = FactoryDTO.GetAnsweredQuestions(this.questions);
    console.log(answeredQuestions);

    this.testService.postAnsweredQuestions(this.selectedTestId, answeredQuestions).subscribe(
      result => {
        this.resultService.resultSubject.next(result as Result);
        this.resultService.isOpenedResultSubject.next(true);

        this.testService.isOpened.next(false);
      },
      error => {
        let message = error.error;
        this.messageService.pushMessage(message);
      }
    );
  }

  test() {
    if (this.isTestOpened == true) {
      this.endTest = true;
    }
    else {
      this.isTestOpened = true;
      this.resultService.isOpenedResult = false;
      this.resultService.isOpenedResultSubject.next(this.resultService.isOpenedResult);
    }

    if (this.endTest == true) {
      this.endTest = confirm("Do you want to finish test?");
      if (this.endTest == true) {
        let answeredQuestions = FactoryDTO.GetAnsweredQuestions(this.questions);
        // this.apiService.answerTest(answeredQuestions).subscribe(result => {
        //   this.resultService.result = <Result>result;
        //   this.resultService.resultSubject.next(this.resultService.result);
        //   this.resultService.isOpenedResult = true;
        //   this.resultService.isOpenedResultSubject.next(this.resultService.isOpenedResult);
        // });

        this.isTestOpened = false;
        this.testService.isOpened.next(this.isTestOpened);

        this.endTest = false;
      }
    }

    this.testService.isOpened.next(this.isTestOpened);
  }

  chat() {
    if (this.chatService.isChatOpened == false) this.chatService.isChatOpened = true;
    else this.chatService.isChatOpened = false;
    
    this.chatService.isChatOpenedSubject.next(this.chatService.isChatOpened);
  }

  logout() {
    this.authService.logout().subscribe(
      response => {
        let message: Message = response as Message;
        this.messageService.pushMessage(message);

        this.authService.isAuthenticatedQuery().subscribe(
          response => {
            this.authService.isAuthenticated.next(false);
          }
        )
      },
      error => {
        let message: Message = error.error as Message;
        this.messageService.pushMessage(message);
      }
    )
  }

  ngOnInit(): void {
  }
}
