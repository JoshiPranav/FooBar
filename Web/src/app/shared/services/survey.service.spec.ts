import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController, TestRequest } from '@angular/common/http/testing';
import { SurveyService } from './survey.service';
import { Survey } from '../entities/survey';
import { MockSurvey } from '../mocks/mock';
import { environment } from '../../../environments/environment';

describe('SurveyService', () => {

  let service: SurveyService;
  let httpTestingController: HttpTestingController;
  
  let survey: Survey = new MockSurvey().survey;

  beforeEach(() => {
    TestBed.configureTestingModule({
        imports: [HttpClientTestingModule],
        providers: [SurveyService]
    });
    service = TestBed.get(SurveyService);
    httpTestingController = TestBed.get(HttpTestingController);
  });

  it('should be created', () => {
    const service: SurveyService = TestBed.get(SurveyService);
    expect(service).toBeTruthy();
  });

  it('should GET a survey', () => {
    service.getSurvey(1).subscribe((success: Boolean) => {
      expect(success).toBe(true);
    });

    let surveyRequest: TestRequest = httpTestingController.expectOne(environment.baseUrl + '/api/survey/1'); 
    surveyRequest.flush(survey);
    
    expect(surveyRequest.request.method).toEqual('GET');
    expect(service.Survey).toEqual(survey);
    httpTestingController.verify();
  });
});
