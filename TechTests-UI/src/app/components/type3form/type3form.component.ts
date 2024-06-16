import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-type3form',
  templateUrl: './type3form.component.html',
  styleUrls: ['./type3form.component.css']
})
export class Type3formComponent implements OnInit {

  @Input() answearText: string = '';
  @Output() answear: EventEmitter<string> = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  setAnswear(answear: string) {
    this.answear.emit(answear);
  }

  log(text: any) {
    console.log(text);
  }
}
