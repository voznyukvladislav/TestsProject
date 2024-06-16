import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Constants } from 'src/app/data/constants';

@Component({
  selector: 'app-type1form',
  templateUrl: './type1form.component.html',
  styleUrls: ['./type1form.component.css']
})
export class Type1formComponent implements OnInit {

  @Input() answearText: string = '';
  @Output() answear: EventEmitter<string> = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  yes() {
    this.answear.emit(Constants.yesAnswear);
  }

  no() {
    this.answear.emit(Constants.noAnswear);
  }
}
