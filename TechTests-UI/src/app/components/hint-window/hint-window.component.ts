import { Component, OnInit } from '@angular/core';
import { HintService } from 'src/app/services/hint-service/hint.service';

@Component({
  selector: 'app-hint-window',
  templateUrl: './hint-window.component.html',
  styleUrls: ['./hint-window.component.css']
})
export class HintWindowComponent implements OnInit {

  constructor(public hintService: HintService) { }

  ngOnInit(): void {
  }

}
