export class UserSurvey {
  nickname: string;
  surveyId: number;
  userAnswers: UserAnswer[] = [];

  constructor(nickname: string, surveyId: number) {
    this.nickname = nickname;
    this.surveyId = surveyId;
  }
}

export class UserAnswer {
  questionId: number;
  answerId: number;

  constructor(questionId: number, answerId: number) {
    this.questionId = questionId;
    this.answerId = answerId;
  }
}
