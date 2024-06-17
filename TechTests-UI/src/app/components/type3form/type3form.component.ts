import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-type3form',
  templateUrl: './type3form.component.html',
  styleUrls: ['./type3form.component.css']
})
export class Type3formComponent implements OnInit {

  @Input() answerText: string = '';
  @Output() answer: EventEmitter<string> = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  setAnswer(answer: string) {
    this.answer.emit(answer);
  }

  log(text: any) {
    console.log(text);
  }
}
