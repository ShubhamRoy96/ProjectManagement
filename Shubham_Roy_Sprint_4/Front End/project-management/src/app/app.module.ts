import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HeaderComponent, NavbarComponent, SidebarComponent, MainContentComponent, FooterComponent } from './shared';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ModalComponent } from './shared/modal/modal.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    NavbarComponent,
    SidebarComponent,
    MainContentComponent,
    FooterComponent,
    ModalComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    AppRoutingModule,
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
