import { Component } from '@angular/core';
import {NgForm} from '@angular/forms';
import { Router } from '@angular/router';
import { UserSurveyService } from '../shared/services/usersurvey.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent {

  constructor(private router: Router, private userSurveyService: UserSurveyService) {
  }

  onSubmit(f: NgForm) {
    const surveyId = 1;
    this.userSurveyService.createNewUserSurvey(f.value.nickname, surveyId);
    this.router.navigate(['survey', surveyId]);
  }

}
