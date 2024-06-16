import { CategoryResult } from "./categoryResult";

export class Result {
    title: string = '';
    categoryResults: CategoryResult[] = [];
    result: number = 0.0;
    total: number = 0.0;
    percentage: string = '';
}