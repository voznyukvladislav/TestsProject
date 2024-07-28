export class Constants {
    static loginTitle: string = "Login";
    static registrationTitle: string = "Registration";
    
    static messageSuccessful: string = "Success";
    static messageFailed: string = "Failed";
    static messageLifetime: number = 5000;
    
    static fastTransition: number = 300;

    // API Constants begin
    static api: string = 'http://localhost:5273/api';

    // Controllers
    static auth: string = "auth";
    static tests: string = 'tests';
    
    // Tests endpoints
    static getTest: string = 'getTest';
    static answerTest: string = 'answerTest';
    static questionGroup: string = "questionGroup";
    static questionGroups: string = "questionGroups";
    static questions: string = "questions";
    static results: string = "results";
    static result: string = "result";

    // Auth endpoints
    static login: string = "login";
    static logout: string = "logout";
    static registration: string = "registration";
    static isAuthenticated: string = "isAuthenticated";
    static isAvailableLogin: string = "isAvailableLogin";
    // API Constants end

    static yesAnswer: string = 'Yes';
    static noAnswer: string = 'No';
}