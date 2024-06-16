import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Question } from 'src/app/data/question';
import { ApiService } from '../api-service/api.service';

@Injectable({
  providedIn: 'root'
})
export class TestService {

  public isOpened: BehaviorSubject<boolean> = new BehaviorSubject(false);
  isOpenedBoolean: boolean = false;

  public questionsValues: Question[] | any = [];
  public questions: BehaviorSubject<Question[]> = new BehaviorSubject<Question[]>(this.questionsValues);

  popup(): boolean {
    this.isOpenedBoolean = !this.isOpenedBoolean;
    this.isOpened.next(this.isOpenedBoolean);
    
    return this.isOpenedBoolean;
  }

  constructor(private apiService: ApiService) {
    this.apiService.getTestQuestions().subscribe(q => {
      this.questionsValues = q;
      this.questions.next(this.questionsValues);
    });
  }
}
