import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController, TestRequest } from '@angular/common/http/testing';
import { UserSurveyService } from './usersurvey.service';
import { UserSurvey } from '../entities/usersurvey';
import { MockUserSurveyService } from '../mocks/mock';
import { environment } from 'src/environments/environment';

describe('UserSurveyService', () => {

  let service: UserSurveyService;
  let httpTestingController: HttpTestingController;
  
  let userSurvey: UserSurvey = new MockUserSurveyService().UserSurvey;

  beforeEach(() => {
    TestBed.configureTestingModule({
        imports: [HttpClientTestingModule],
        providers: [UserSurveyService]
    });
    service = TestBed.get(UserSurveyService);
    httpTestingController = TestBed.get(HttpTestingController);
  });

  it('should be created', () => {
    const service: UserSurveyService = TestBed.get(UserSurveyService);
    expect(service).toBeTruthy();
  });

  it('should POST a user survey', () => {
    service.UserSurvey = userSurvey;
    service.postSurveyData().subscribe((success: Boolean) => {
      expect(success).toBe(true);
    });

    let userSurveyRequest: TestRequest = httpTestingController.expectOne(environment.baseUrl + '/api/usersurvey'); 
    userSurveyRequest.flush(3);
    
    expect(userSurveyRequest.request.method).toEqual('POST');
    httpTestingController.verify();
  });

  it('should create a new user survey object', () => {
    service.createNewUserSurvey('Tom', 1);

    expect(service.UserSurvey.nickname).toBe('Tom');
    expect(service.UserSurvey.surveyId).toBe(1);
  });

  it('should add a new survey answer object', () => {
    service.UserSurvey = new UserSurvey('Tom', 1);
    
    service.updateUserSurveyAnswer(1, 2);
    
    expect(service.UserSurvey.userAnswers.length).toBe( 1);
    expect(service.UserSurvey.userAnswers[0].questionId).toBe(1);
    expect(service.UserSurvey.userAnswers[0].answerId).toBe(2);
  });
});
