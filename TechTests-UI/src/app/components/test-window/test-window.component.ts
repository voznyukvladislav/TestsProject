import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Question } from 'src/app/data/question';
import { ApiService } from 'src/app/services/api-service/api.service';
import { OpenaiApiService } from 'src/app/services/openai-api-service/openai-api.service';
import { TestService } from 'src/app/services/test-service/test.service';

@Component({
  selector: 'app-test-window',
  templateUrl: './test-window.component.html',
  styleUrls: ['./test-window.component.css']
})
export class TestWindowComponent implements OnInit {
  questions: any = [];
  questionIndex: number = 0;

  constructor(public testService: TestService) {
    this.testService.questions.subscribe(q => {
      this.questions = q;
    });
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
  }
  
  right() {
    let questionBlock: any = document.getElementById("question-block");
    questionBlock.style.opacity = 0;
    
    setTimeout(() => {
      if (this.questionIndex < this.questions.length - 1) this.questionIndex++;
      else this.questionIndex = 0;
      questionBlock.style.opacity = 1;
    }, 200);
  }

  notifyTestService() {
    this.testService.questions.next(this.questions);
  }
}
