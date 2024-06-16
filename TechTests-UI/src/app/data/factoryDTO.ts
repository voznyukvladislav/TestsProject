import { AnswearedQuestion } from "./answearedQuestion";
import { Question } from "./question";

export class FactoryDTO {
    static GetAnswearedQuestions(questions: Question[]): AnswearedQuestion[] {
        let answearedQuestions: AnswearedQuestion[] = [];
        for (let i = 0; i < questions.length; i++) {
          let answearedQuestion = new AnswearedQuestion();
          answearedQuestion.id = questions[i].id;
          answearedQuestion.answear = questions[i].answear;

          answearedQuestions.push(answearedQuestion);
        }

        return answearedQuestions;
    }
}