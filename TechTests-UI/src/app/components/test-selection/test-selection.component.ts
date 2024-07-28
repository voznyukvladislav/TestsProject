import { Component, OnInit } from '@angular/core';
import { QuestionGroup } from 'src/app/data/questionGroup';
import { TestService } from 'src/app/services/test-service/test.service';

@Component({
  selector: 'app-test-selection',
  templateUrl: './test-selection.component.html',
  styleUrls: ['./test-selection.component.css']
})
export class TestSelectionComponent implements OnInit {

  title: string = 'Tests...';
  isOpenedList: boolean = false;

  selectedQuestionGroup: QuestionGroup = new QuestionGroup();

  questionGroups: QuestionGroup[] = [];

  constructor(private testService: TestService) {
    this.testService.getQuestionGroups().subscribe(
      questionGroups => {
        this.questionGroups = questionGroups as QuestionGroup[];
      }
    )
  }

  list() {
    this.isOpenedList = !this.isOpenedList;
  }

  select(index: number) {
    this.title = this.questionGroups[index].name;
    this.selectedQuestionGroup = this.questionGroups[index];
    this.list();
  }

  apply() {
    if (this.selectedQuestionGroup.id == 0) return;
    
    this.testService.selectedTestId.next(this.selectedQuestionGroup.id);
    this.testService.isTestSelectionWindowOpened.next(false);
    this.testService.isOpened.next(true);
  }

  ngOnInit(): void {
  }

}
