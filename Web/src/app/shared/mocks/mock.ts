import { UserSurvey } from '../entities/usersurvey';
import { Survey } from '../entities/survey';
import { Observable } from 'rxjs/internal/Observable';
import { of } from 'rxjs';

export class MockSurvey {
  public survey: Survey = {
    id: 1,
    name: null,
    description: 'This is a general survey about favourite things',
    surveyQuestions: [
        {
            id: 2,
            questionText: 'What is your favourite animal?',
            sortOrder: 1,
            surveyQuestionAnswers: [
                {
                    id: 5,
                    answerText: 'Dog',
                    sortOrder: 1
                },
                {
                    id: 7,
                    answerText: 'Lion',
                    sortOrder: 2
                },
                {
                    id: 6,
                    answerText: 'Cat',
                    sortOrder: 3
                }
            ]
        },
        {
            id: 3,
            questionText: 'What is your favourite bird?',
            sortOrder: 2,
            surveyQuestionAnswers: [
                {
                    id: 8,
                    answerText: 'Parrot',
                    sortOrder: 2
                },
                {
                    id: 10,
                    answerText: 'Owl',
                    sortOrder: 3
                },
                {
                    id: 9,
                    answerText: 'Eagle',
                    sortOrder: 4
                },
                {
                    id: 11,
                    answerText: 'Hummingbird',
                    sortOrder: 4
                }
            ]
        },
        {
            id: 1,
            questionText: 'What is your favourite color?',
            sortOrder: 3,
            surveyQuestionAnswers: [
                {
                    id: 2,
                    answerText: 'Blue',
                    sortOrder: 1
                },
                {
                    id: 1,
                    answerText: 'Red',
                    sortOrder: 2
                },
                {
                    id: 4,
                    answerText: 'Yellow',
                    sortOrder: 3
                },
                {
                    id: 3,
                    answerText: 'Green',
                    sortOrder: 4
                }
            ]
        }
    ]
  };
}
export class MockUserSurveyService {
  UserSurvey: UserSurvey = {
    userAnswers: [
       {
          questionId: 2,
          answerId: 7
       },
       {
          questionId: 3,
          answerId: 9
       },
       {
          questionId: 1,
          answerId: 3
       }
    ],
    nickname: 'j',
    surveyId: 1
 };
 
  postSurveyData(): Observable<boolean> {
    return of(true);
  }
 updateUserSurveyAnswer(questionId: number, answerId: number) { }
 createNewUserSurvey(userNickname: string, surveyId: number) {
    this.UserSurvey = new UserSurvey(userNickname, surveyId);
  }
}

export class MockSurveyService {
  survey: Survey = new MockSurvey().survey;
}
