import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WelcomeComponent } from './welcome/welcome.component';
import { SurveyComponent } from './survey/survey.component';
import { QuestionComponent } from './question/question.component';
import { FinishComponent } from './finish/finish.component';
import { ErrorComponent } from './error/error.component';
import { SurveyDataResolver } from './shared/resolvers/survey-data.resolver';


export const routes: Routes = [
  { path: '', component: WelcomeComponent },
  { path: 'survey/:surveyId', 
    component: SurveyComponent, 
    resolve:{         
          survey:SurveyDataResolver  
    }   
   },
  { path: 'question', component: QuestionComponent },
  { path: 'finish', component: FinishComponent },
  { path: 'error/:errorMessage', component: ErrorComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
