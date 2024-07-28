import { Component, OnInit } from '@angular/core';
import { Result } from 'src/app/data/result';
import { ChatService } from 'src/app/services/chat-service/chat.service';
import { HintService } from 'src/app/services/hint-service/hint.service';
import { ResultService } from 'src/app/services/result-service/result.service';
import { TestService } from 'src/app/services/test-service/test.service';

@Component({
  selector: 'app-body',
  templateUrl: './body.component.html',
  styleUrls: ['./body.component.css']
})
export class BodyComponent implements OnInit {

  isOpenedTestWindow: boolean = false;
  isOpenedTestSelectionWindow: boolean = false;
  isOpenedHintWindow: boolean = false;
  isOpenedChatWindow: boolean = false;

  result: Result = new Result();
  isOpenedResult: boolean = false;

  isOpenedResultsWindow: boolean = false;

  constructor(
    private testService: TestService,
    private hintService: HintService,
    private resultService: ResultService,
    private chatService: ChatService) {

    testService.isOpened.subscribe((v) => {
      this.isOpenedTestWindow = v;
    });

    testService.isTestSelectionWindowOpened.subscribe(v => {
      this.isOpenedTestSelectionWindow = v;
    });

    hintService.isOpenedHintWindow.subscribe((v) => {
      this.isOpenedHintWindow = v;
    });

    chatService.isChatOpenedSubject.subscribe(v => {
      this.isOpenedChatWindow = v;
    });

    resultService.resultSubject.subscribe(r => {
      this.result = r;
    });

    resultService.isOpenedResultSubject.subscribe(v => {
      this.isOpenedResult = v;
    });

    resultService.isOpenedResultsWindow.subscribe(
      isOpened => this.isOpenedResultsWindow = isOpened
    )
  }

  ngOnInit(): void {
  }

}
