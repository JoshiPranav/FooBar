import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SurveyService } from '../shared/services/survey.service';
import { Survey, SurveyQuestionAnswer, SurveyQuestion } from '../shared/entities/survey';
import { UserSurveyService } from '../shared/services/usersurvey.service';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent implements OnInit {

  public survey: Survey;
  public currentQuestionIndex = 0;
  public currentQuestion: SurveyQuestion;
  public selectedAnswer: SurveyQuestionAnswer;

  constructor(private surveyService: SurveyService,
              private userSurveyService: UserSurveyService,
              private router: Router) {
}

  ngOnInit() {
     this.survey = this.surveyService.Survey;
     if (this.survey) {
       this.currentQuestion = this.survey.surveyQuestions[this.currentQuestionIndex];
     }
     this.selectedAnswer = null;
  }

  onAnswerSelected(selectedAnswer: SurveyQuestionAnswer) {
    this.userSurveyService.updateUserSurveyAnswer(this.currentQuestion.id, selectedAnswer.id);
    this.selectedAnswer = selectedAnswer;
  }

  goToNextQuestion() {
    this.currentQuestionIndex = this.currentQuestionIndex + 1;
    this.currentQuestion = this.survey.surveyQuestions[this.currentQuestionIndex];
    this.selectedAnswer = null;
    if (this.currentQuestionIndex === this.survey.surveyQuestions.length) {
      this.userSurveyService.postSurveyData().subscribe((success) => {
        if (success) {
          this.router.navigate(['finish']);
        }
      });
    }
  }
}
