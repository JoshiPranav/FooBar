export class Survey {
  id: number;
  name: string;
  description: string;
  surveyQuestions: SurveyQuestion[] = [];
}

export class SurveyQuestion {
  id: number;
  questionText: string;
  sortOrder: number;
  surveyQuestionAnswers: SurveyQuestionAnswer[] = [];
}

export class SurveyQuestionAnswer {
  id: number;
  answerText: string;
  sortOrder: number;
  constructor(id: number, answerText: string, sortOrder: number) {
    this.id = id;
    this.answerText = answerText;
    this.sortOrder = sortOrder;
  }
}
