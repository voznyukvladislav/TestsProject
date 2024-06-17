import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Result } from 'src/app/data/result';

@Injectable({
  providedIn: 'root'
})
export class ResultService {

  public result: Result = new Result();
  public resultSubject: BehaviorSubject<Result> = new BehaviorSubject<Result>(this.result);

  public isOpenedResult: boolean = false;
  public isOpenedResultSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(this.isOpenedResult);

  public aiHelpCounter: number = 0;
  public aiHelpCounterSubject: BehaviorSubject<number> = new BehaviorSubject<number>(this.aiHelpCounter);

  constructor() { }

}
