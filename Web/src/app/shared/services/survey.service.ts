import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Survey } from '../entities/survey';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SurveyService {
  public Survey: Survey;
  constructor(private http: HttpClient) { }

  getSurvey(surveyId: number): Observable<boolean> {
    return this.http.get(environment.baseUrl + '/api/survey/' + surveyId)
      .pipe(
        map((data: any) => {
          this.Survey = data;
          return true;
        }));
  }
}
