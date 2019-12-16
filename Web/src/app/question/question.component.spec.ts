import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionComponent } from './question.component';
import { RouterTestingModule } from '@angular/router/testing';
import { FormsModule } from '@angular/forms';
import { SurveyQuestionAnswer } from '../shared/entities/survey';

describe('QuestionComponent', () => {
  let component: QuestionComponent;
  let fixture: ComponentFixture<QuestionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        FormsModule
      ],
      declarations: [ QuestionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('raises the selected event when answer is selected', () => {
    const comp = new QuestionComponent();
    const answer: SurveyQuestionAnswer = new SurveyQuestionAnswer(1, 'cat', 1);
    comp.selectedAnswer = answer;

    comp.answerSelected.subscribe((ans: SurveyQuestionAnswer) => expect(ans).toBe(answer));
    comp.selectAnswer(answer);
  });
});
