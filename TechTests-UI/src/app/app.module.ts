import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { BodyComponent } from './components/body/body.component';
import { TestWindowComponent } from './components/test-window/test-window.component';
import { HintWindowComponent } from './components/hint-window/hint-window.component';
import { QuestionComponent } from './components/question/question.component';
import { Type1formComponent } from './components/type1form/type1form.component';
import { Type2formComponent } from './components/type2form/type2form.component';
import { Type3formComponent } from './components/type3form/type3form.component';
import { ResultWindowComponent } from './components/result-window/result-window.component';
import { ChatWindowComponent } from './components/chat-window/chat-window.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    BodyComponent,
    TestWindowComponent,
    HintWindowComponent,
    QuestionComponent,
    Type1formComponent,
    Type2formComponent,
    Type3formComponent,
    ResultWindowComponent,
    ChatWindowComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
