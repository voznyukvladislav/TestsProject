import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-type2form',
  templateUrl: './type2form.component.html',
  styleUrls: ['./type2form.component.css']
})
export class Type2formComponent implements OnInit {

  @Input() answerText: string = '';
  @Output() answer: EventEmitter<string> = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  setAnswer(answer: string) {
    this.answer.emit(answer);
  }
}
