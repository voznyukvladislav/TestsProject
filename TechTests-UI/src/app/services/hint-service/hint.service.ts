import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HintService {

  public isOpenedHintWindow: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  isOpenedBoolean: boolean = false;

  popup(): void {
    this.isOpenedBoolean = !this.isOpenedBoolean;
    this.isOpenedHintWindow.next(this.isOpenedBoolean);
  }

  constructor() { }
}
