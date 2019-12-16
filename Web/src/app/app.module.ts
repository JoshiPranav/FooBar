import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { SurveyComponent } from './survey/survey.component';
import { QuestionComponent } from './question/question.component';
import { SurveyService } from './shared/services/survey.service';
import { FormsModule } from '@angular/forms';
import { FinishComponent } from './finish/finish.component';
import { UserSurveyService } from './shared/services/usersurvey.service';
import { HttpErrorInterceptor } from './shared/interceptors/HttpErrorInterceptor';
import { ErrorComponent } from './error/error.component';
import { SurveyDataResolver } from './shared/resolvers/survey-data.resolver';

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    SurveyComponent,
    QuestionComponent,
    FinishComponent,
    ErrorComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    SurveyService,
    UserSurveyService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptor,
      multi: true,
    },
    SurveyDataResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
