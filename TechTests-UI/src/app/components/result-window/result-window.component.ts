import { Component, Input, OnInit } from '@angular/core';
import { Result } from 'src/app/data/result';
import { ResultService } from 'src/app/services/result-service/result.service';

@Component({
  selector: 'app-result-window',
  templateUrl: './result-window.component.html',
  styleUrls: ['./result-window.component.css']
})
export class ResultWindowComponent implements OnInit {

  @Input() result: Result = new Result();

  aiHelpCounter: number = 0;

  constructor(private resultService: ResultService) {
    this.resultService.aiHelpCounterSubject.subscribe(counter => {
      this.aiHelpCounter = counter;
    })
  }

  ngOnInit(): void {
  }

  close() {
    this.resultService.isOpenedResult = false;
    this.resultService.isOpenedResultSubject.next(this.resultService.isOpenedResult);

    console.log(this.result);
  }

}
