import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Constants } from 'src/app/data/constants';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getTestQuestions() {
    return this.http.get(`${Constants.api}/${Constants.tests}/${Constants.getTest}?count=50`);
  }

  answerTest(questions: any[]) {
    return this.http.post(`${Constants.api}/${Constants.tests}/${Constants.answerTest}`, questions);
  }
}
