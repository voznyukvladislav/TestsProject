import { AnsweredQuestion } from "./answeredQuestion";
import { Question } from "./question";

export class FactoryDTO {
    static GetAnsweredQuestions(questions: Question[]): AnsweredQuestion[] {
        let answeredQuestions: AnsweredQuestion[] = [];
        for (let i = 0; i < questions.length; i++) {
          let answeredQuestion = new AnsweredQuestion();
          answeredQuestion.id = questions[i].id;
          answeredQuestion.answer = questions[i].answer;

          answeredQuestions.push(answeredQuestion);
        }

        return answeredQuestions;
    }
}