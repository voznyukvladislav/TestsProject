import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  public isChatOpened: boolean = false;
  public isChatOpenedSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(this.isChatOpened);

  popup() {
    this.isChatOpened = !this.isChatOpened;
    this.isChatOpenedSubject.next(this.isChatOpened);
  }

  constructor() { }
}
