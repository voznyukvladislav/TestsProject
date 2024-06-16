import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ChatService } from 'src/app/services/chat-service/chat.service';
import { OpenaiApiService } from 'src/app/services/openai-api-service/openai-api.service';

@Component({
  selector: 'app-chat-window',
  templateUrl: './chat-window.component.html',
  styleUrls: ['./chat-window.component.css']
})
export class ChatWindowComponent implements OnInit {

  @ViewChild('input') input : ElementRef | any;

  messages: any[] = [];
  messageText: string = '';

  constructor(private chatService: ChatService, private openaiApiService: OpenaiApiService) { }

  ngOnInit(): void {
  }

  chat() {
    this.chatService.isChatOpened = false;
    this.chatService.isChatOpenedSubject.next(this.chatService.isChatOpened);
  }

  sendMessage() {
    let chatWindow = document.getElementById("chat");
    this.messages.push({role: 'user', content: `${this.messageText}`});
    setTimeout(() => {
      chatWindow?.scrollTo(0, chatWindow.scrollHeight);
    });

    this.openaiApiService.request(this.messages).subscribe((response: any) => {
      console.log(response);
      let assistantMessage = response.choices[0].message;
      this.messages.push(assistantMessage);

      setTimeout(() => {
        chatWindow?.scrollTo(0, chatWindow.scrollHeight);
      });
    });
    this.messageText = '';
  }
}
