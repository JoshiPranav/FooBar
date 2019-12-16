import { Injectable } from "@angular/core";  
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";  
import { Observable } from "rxjs";  
import { SurveyService } from '../services/survey.service';

@Injectable()  
export class SurveyDataResolver implements Resolve<boolean> {  
  constructor(private surveyService: SurveyService) {}  
  
  resolve(route: ActivatedRouteSnapshot): Observable<boolean> {
    const surveyId = Number(route.params.surveyId);
    return this.surveyService.getSurvey(surveyId);  
  }  
}  