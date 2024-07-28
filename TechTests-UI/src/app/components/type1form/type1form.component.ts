import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Constants } from 'src/app/data/constants';

@Component({
  selector: 'app-type1form',
  templateUrl: './type1form.component.html',
  styleUrls: ['./type1form.component.css']
})
export class Type1formComponent implements OnInit {

  yesAnswer: string = Constants.yesAnswer;
  noAnswer: string = Constants.noAnswer;

  @Input() answerText: string = '';
  @Output() answer: EventEmitter<string> = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  yes() {
    this.answer.emit(Constants.yesAnswer);
  }

  no() {
    this.answer.emit(Constants.noAnswer);
  }
}
