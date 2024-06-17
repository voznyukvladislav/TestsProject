import { Component, OnInit } from '@angular/core';
import { AnsweredQuestion } from 'src/app/data/answeredQuestion';
import { FactoryDTO } from 'src/app/data/factoryDTO';
import { Result } from 'src/app/data/result';
import { ApiService } from 'src/app/services/api-service/api.service';
import { ChatService } from 'src/app/services/chat-service/chat.service';
import { HintService } from 'src/app/services/hint-service/hint.service';
import { OpenaiApiService } from 'src/app/services/openai-api-service/openai-api.service';
import { ResultService } from 'src/app/services/result-service/result.service';
import { TestService } from 'src/app/services/test-service/test.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  title: string = "Почати тест";

  isTestOpened: boolean = false;
  endTest: boolean = false;

  questions: any[] = [];

  constructor(
    public testService: TestService,
    public hintService: HintService,
    public apiService: ApiService,
    public resultService: ResultService,
    public chatService: ChatService
    ) {
      this.testService.questions.subscribe(q => {
      this.questions = q;
    });
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
      this.endTest = confirm("Чи бажаєте ви закінчити тест?");
      if (this.endTest == true) {
        let answeredQuestions = FactoryDTO.GetAnsweredQuestions(this.questions);
        this.apiService.answerTest(answeredQuestions).subscribe(result => {
          this.resultService.result = <Result>result;
          this.resultService.resultSubject.next(this.resultService.result);
          this.resultService.isOpenedResult = true;
          this.resultService.isOpenedResultSubject.next(this.resultService.isOpenedResult);
        });

        this.isTestOpened = false;
        this.testService.isOpened.next(this.isTestOpened);

        this.endTest = false;
      }
    }
    
    if (this.isTestOpened) this.title = "Закінчити тест";
    else this.title = "Почати тест";

    this.testService.isOpened.next(this.isTestOpened);
  }

  chat() {
    if (this.chatService.isChatOpened == false) this.chatService.isChatOpened = true;
    else this.chatService.isChatOpened = false;
    
    this.chatService.isChatOpenedSubject.next(this.chatService.isChatOpened);
  }

  ngOnInit(): void {
  }
}
