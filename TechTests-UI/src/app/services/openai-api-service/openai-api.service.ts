import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Secrets } from 'src/app/data/secrets';

@Injectable({
  providedIn: 'root'
})
export class OpenaiApiService {

  constructor(private http: HttpClient) { }

  request(messages: any[]) {
    let address: string = 'https://api.openai.com/v1/chat/completions';
    let apiKey: string = Secrets.openaiApiKey;

    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${apiKey}`,
    });

    let body = {
      model: 'gpt-4o',
      messages: messages
    };

    return this.http.post(address, body, { headers });
  }
}
