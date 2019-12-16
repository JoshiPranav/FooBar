import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { SurveyComponent } from './survey.component';
import { RouterTestingModule } from '@angular/router/testing';
import { QuestionComponent } from '../question/question.component';
import { FormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { SurveyQuestionAnswer, SurveyQuestion } from '../shared/entities/survey';
import { SurveyService } from '../shared/services/survey.service';
import { UserSurveyService } from '../shared/services/usersurvey.service';
import { MockSurveyService, MockUserSurveyService, MockSurvey } from '../shared/mocks/mock';
import { Router } from '@angular/router';

describe('SurveyComponent', () => {
  let component: SurveyComponent;
  let fixture: ComponentFixture<SurveyComponent>;
  let userSurveyService: UserSurveyService;
  let surveyService: SurveyService;
  let router: Router;
  
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        FormsModule,
        HttpClientTestingModule
      ],
      providers: [
        SurveyComponent,
        QuestionComponent,
        { provide: SurveyService, useClass: MockSurveyService },
        { provide: UserSurveyService, useClass: MockUserSurveyService }
      ],
      declarations: [ SurveyComponent, QuestionComponent ]
    })
    .compileComponents()
    .then(() => {
      fixture = TestBed.createComponent(SurveyComponent);
      component = fixture.componentInstance;
      userSurveyService = TestBed.get(UserSurveyService);
      surveyService = TestBed.get(SurveyService);
      router = TestBed.get(Router);
      fixture.detectChanges();
    });
  }));

  beforeEach(() => {

  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should mark selected answer', () => {
    const mockSelectedAnswer: SurveyQuestionAnswer = new SurveyQuestionAnswer(1, 'cat', 1);
    component.currentQuestion = new SurveyQuestion();
    component.currentQuestion.sortOrder = 1;
    component.currentQuestion.id = 1;

    component.onAnswerSelected(mockSelectedAnswer);

    expect(component.selectedAnswer.id).toBe(mockSelectedAnswer.id);
    expect(component.selectedAnswer.answerText).toBe(mockSelectedAnswer.answerText);
    expect(component.selectedAnswer.sortOrder).toBe(mockSelectedAnswer.sortOrder);
  });

  it('should set correct values when goToNextQuestion is called', () => {
    component.currentQuestionIndex = 1;
    component.survey = new MockSurvey().survey;
    component.currentQuestion = component.survey.surveyQuestions[1];
    const mockSelectedAnswer: SurveyQuestionAnswer = new SurveyQuestionAnswer(1, 'cat', 1);

    component.goToNextQuestion();

    expect(component.currentQuestionIndex).toBe(2);
    expect(component.currentQuestion).toBe(component.survey.surveyQuestions[2]);
    expect(component.selectedAnswer).toBeNull();
  });

  it('should navigate to next question when currect question is answered', () => {
    component.currentQuestionIndex = 2;
    component.survey = new MockSurvey().survey;
    const navigateSpy = spyOn(router, 'navigate');
    
    component.goToNextQuestion();

    expect(navigateSpy).toHaveBeenCalledWith(['finish']);
  });
});
