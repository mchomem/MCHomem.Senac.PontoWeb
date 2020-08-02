import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PontoListComponent } from './ponto/ponto-list/ponto-list.component';
import { PontoDetailsComponent } from './ponto/ponto-details/ponto-details.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    PontoListComponent,
    PontoDetailsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: PontoDetailsComponent, pathMatch: 'full' },      
      { path: 'ponto-details', component: PontoDetailsComponent },
      { path: 'ponto-list', component: PontoListComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
