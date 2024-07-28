import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Message } from 'src/app/data/message';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  messageBehaviorSubject: BehaviorSubject<Message> = new BehaviorSubject<Message>(new Message());
  
  pushMessage(message: Message) {
    this.messageBehaviorSubject.next(message);
  }

  constructor() { }
}
