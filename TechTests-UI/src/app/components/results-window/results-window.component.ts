import { Component, OnInit } from '@angular/core';
import { Result } from 'src/app/data/result';
import { ResultShort } from 'src/app/data/resultShort';
import { ResultService } from 'src/app/services/result-service/result.service';

@Component({
  selector: 'app-results-window',
  templateUrl: './results-window.component.html',
  styleUrls: ['./results-window.component.css']
})
export class ResultsWindowComponent implements OnInit {
  title: string = "Results";
  shortResults: ResultShort[] = [];

  constructor(private resultsService: ResultService) {
    this.resultsService.shortResults.subscribe(
      results => this.shortResults = results
    );
  }

  close() {
    this.resultsService.isOpenedResultsWindow.next(false);
  }

  showResult(index: number) {
    let resultId = this.shortResults[index].resultId;
    this.resultsService.getResult(resultId).subscribe(
      result => {
        this.resultsService.resultSubject.next(result as Result);

        this.resultsService.isOpenedResultsWindow.next(false);
        this.resultsService.isOpenedResultSubject.next(true);
      }
    );   
  }

  ngOnInit(): void {
  }

}
