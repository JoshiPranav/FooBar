import { Injectable } from '@angular/core';
import { UserSurvey, UserAnswer } from '../entities/usersurvey';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserSurveyService {

  public UserSurvey: UserSurvey;
  private endpoint = environment.baseUrl + '/api/usersurvey';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private http: HttpClient) { }

  createNewUserSurvey(userNickname: string, surveyId: number) {
    this.UserSurvey = new UserSurvey(userNickname, surveyId);
  }

  updateUserSurveyAnswer(questionId: number, answerId: number) {
    this.UserSurvey.userAnswers.push(new UserAnswer(questionId, answerId));
  }

  postSurveyData(): Observable<boolean> {
    return this.http.post<UserSurvey>(this.endpoint, this.UserSurvey, this.httpOptions)
      .pipe(
        map((data: any) => {
          return true;
        }));
  }
}
