import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { SurveyQuestion, SurveyQuestionAnswer } from '../shared/entities/survey';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {

  @Input() surveyQuestion: SurveyQuestion;
  @Output() answerSelected = new EventEmitter<SurveyQuestionAnswer>();
  selectedAnswer: any;
  constructor() { }

  ngOnInit() {
  }

  selectAnswer(selectedAnswer: SurveyQuestionAnswer) {
    this.answerSelected.emit(selectedAnswer);
  }
}
