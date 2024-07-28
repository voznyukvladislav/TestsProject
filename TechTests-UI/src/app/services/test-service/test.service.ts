import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Question } from 'src/app/data/question';
import { HttpClient } from '@angular/common/http';
import { Constants } from 'src/app/data/constants';
import { AnsweredQuestion } from 'src/app/data/answeredQuestion';

@Injectable({
  providedIn: 'root'
})
export class TestService {

  public isOpened: BehaviorSubject<boolean> = new BehaviorSubject(false);
  isOpenedBoolean: boolean = false;

  public isTestSelectionWindowOpened: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public selectedTestId: BehaviorSubject<number> = new BehaviorSubject(0);

  public questions: BehaviorSubject<Question[]> = new BehaviorSubject<Question[]>([]);

  popup(): boolean {
    this.isOpenedBoolean = !this.isOpenedBoolean;
    this.isOpened.next(this.isOpenedBoolean);
    
    return this.isOpenedBoolean;
  }

  getQuestionGroups() {
    return this.http.get(`${Constants.api}/${Constants.tests}/${Constants.questionGroups}`);
  }

  getQuestionGroup(questionGroupId: number) {
    return this.http.get(`${Constants.api}/${Constants.tests}/${Constants.questionGroup}?questionGroupId=${questionGroupId}`);
  }

  getQuestions(questionGroupId: number) {
    return this.http.get(`${Constants.api}/${Constants.tests}/${Constants.questions}?questionGroupId=${questionGroupId}`);
  }

  postAnsweredQuestions(questionGroupId: number, answeredQuestions: AnsweredQuestion[]) {
    return this.http.post(`${Constants.api}/${Constants.tests}/${Constants.answerTest}?questionGroupId=${questionGroupId}`, answeredQuestions, { withCredentials: true });
  }

  constructor(private http: HttpClient) {
    
  }
}
