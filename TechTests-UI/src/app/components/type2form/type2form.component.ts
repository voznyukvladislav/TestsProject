import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-type2form',
  templateUrl: './type2form.component.html',
  styleUrls: ['./type2form.component.css']
})
export class Type2formComponent implements OnInit {

  @Input() answearText: string = '';
  @Output() answear: EventEmitter<string> = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  setAnswear(answear: string) {
    this.answear.emit(answear);
  }
}
