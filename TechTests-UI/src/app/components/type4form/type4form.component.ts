import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Answer } from 'src/app/data/answer';

@Component({
  selector: 'app-type4form',
  templateUrl: './type4form.component.html',
  styleUrls: ['./type4form.component.css']
})
export class Type4formComponent implements OnInit {

  @Input() answers: Answer[] = [];
  @Output() setAnswer: EventEmitter<string> = new EventEmitter<string>();
  @ViewChild("answersBlock") answersBlock: HTMLElement | any;

  constructor() { }

  ngOnInit(): void {
  }

  check(index: number) {
    for (let i = 0; i < this.answers.length; i++) {
      if (i != index) this.answers[i].checked = false;
      else this.answers[i].checked = true;
    }

    this.setAnswer.emit(`${this.answers[index].id}`);
  }
}
