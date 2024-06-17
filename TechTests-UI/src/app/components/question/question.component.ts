import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { Question } from 'src/app/data/question';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {

  @Input() question: Question = new Question();
  @Output() notifyTestService: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor() {}

  ngOnInit(): void {
  }

  setAnswer(answer: string) {
    this.question.answer = answer;
  }
}
