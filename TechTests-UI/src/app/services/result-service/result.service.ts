import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Constants } from 'src/app/data/constants';
import { Result } from 'src/app/data/result';
import { ResultShort } from 'src/app/data/resultShort';

@Injectable({
  providedIn: 'root'
})
export class ResultService {

  public result: Result = new Result();
  public resultSubject: BehaviorSubject<Result> = new BehaviorSubject<Result>(this.result);

  public isOpenedResult: boolean = false;
  public isOpenedResultSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(this.isOpenedResult);

  public isOpenedResultsWindow: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public shortResults: BehaviorSubject<ResultShort[]> = new BehaviorSubject<ResultShort[]>([]);

  public aiHelpCounter: number = 0;
  public aiHelpCounterSubject: BehaviorSubject<number> = new BehaviorSubject<number>(this.aiHelpCounter);

  constructor(private http: HttpClient) { }

  getResults() {
    return this.http.get(`${Constants.api}/${Constants.tests}/${Constants.results}`, {withCredentials: true});
  }

  getResult(resultId: number) {
    return this.http.get(`${Constants.api}/${Constants.tests}/${Constants.result}?resultId=${resultId}`, {withCredentials: true});
  }
}
