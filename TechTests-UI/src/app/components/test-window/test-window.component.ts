import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Question } from 'src/app/data/question';
import { QuestionGroup } from 'src/app/data/questionGroup';
import { OpenaiApiService } from 'src/app/services/openai-api-service/openai-api.service';
import { TestService } from 'src/app/services/test-service/test.service';

@Component({
  selector: 'app-test-window',
  templateUrl: './test-window.component.html',
  styleUrls: ['./test-window.component.css']
})
export class TestWindowComponent implements OnInit {

  testId: number = 0;
  testName: string = '';

  questions: any = [];
  questionIndex: number = 0;

  constructor(public testService: TestService) {
    this.testService.questions.subscribe(q => {
      this.questions = q;
    });

    this.testService.selectedTestId.subscribe(
      value => {
        this.testId = value;

        this.testService.getQuestions(this.testId).subscribe(
          questions => {
            this.questions = questions as Question[];
            this.testService.questions.next(this.questions);
          }
        );

        this.testService.getQuestionGroup(this.testId).subscribe(
          questionGroup => {
            this.testName = (questionGroup as QuestionGroup).name
          }
        );
      }
    )
  }

  ngOnInit(): void {
  }

  left() {
    let questionBlock: any = document.getElementById("question-block");
    questionBlock.style.opacity = 0;

    setTimeout(() => {
      if (this.questionIndex > 0) this.questionIndex--;
      else this.questionIndex = this.questions.length - 1;
      questionBlock.style.opacity = 1;
    }, 200);
    
    this.notifyTestService();
  }
  
  right() {
    let questionBlock: any = document.getElementById("question-block");
    questionBlock.style.opacity = 0;
    
    setTimeout(() => {
      if (this.questionIndex < this.questions.length - 1) this.questionIndex++;
      else this.questionIndex = 0;
      questionBlock.style.opacity = 1;
    }, 200);

    this.notifyTestService();
  }

  notifyTestService() {
    this.testService.questions.next(this.questions);
  }
}
