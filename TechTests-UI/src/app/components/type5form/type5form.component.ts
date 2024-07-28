import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Answer } from 'src/app/data/answer';

@Component({
  selector: 'app-type5form',
  templateUrl: './type5form.component.html',
  styleUrls: ['./type5form.component.css']
})
export class Type5formComponent implements OnInit {

  @Input() answers: Answer[] = [];
  @Output() setAnswer: EventEmitter<string> = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  check(index: number) {
    this.answers[index].checked = !this.answers[index].checked;

    let selectedAnswers: string = '';
    for (let i = 0; i < this.answers.length; i++) {
      if (this.answers[i].checked) selectedAnswers += `${this.answers[i].id},`;
    }
    
    if (selectedAnswers.endsWith(',')) selectedAnswers = selectedAnswers.slice(0, -1);

    this.setAnswer.emit(selectedAnswers);
  }
}
