import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PersonSearchComponent } from './person/person.component';
import { PersonDisplayCardComponent } from './person/person-display-card/person-display-card.component';
import { AllPersonsComponent } from './all-persons/all-persons.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    PersonSearchComponent,
    PersonDisplayCardComponent,
    AllPersonsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: PersonSearchComponent },
      { path: 'everyone', component: AllPersonsComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
