import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { Constants } from 'src/app/data/constants';
import { Message } from 'src/app/data/message';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent implements OnInit, AfterViewInit {
  @ViewChild("messageBlock") messageBlock: HTMLElement | any;
  @ViewChild("underline") underlineBlock: HTMLElement | any;
  @Input() message: Message = new Message();

  statusSuccess: string = Constants.messageSuccessful;
  statusFailed: string = Constants.messageFailed;

  constructor() { }

  ngOnInit(): void {
    setTimeout(() => {
      this.messageBlock.nativeElement.style.opacity = "0";
    }, Constants.messageLifetime);
  }

  ngAfterViewInit(): void { 
    this.underlineBlock.nativeElement.style.width = "0";

    setTimeout(() => {
      this.messageBlock.nativeElement.style.opacity = "1";
      this.underlineBlock.nativeElement.style.width = "100%";
    }, 0);
  }
}
