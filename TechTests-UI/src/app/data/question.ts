import { Answer } from "./answer";

export class Question {
    id: number = 0;
    question: string = '';
    title: string = '';
    description: string = '';
    categories: string = '';
    type: string = '';
    answer: string = '';
    answers: Answer[] = [];
}