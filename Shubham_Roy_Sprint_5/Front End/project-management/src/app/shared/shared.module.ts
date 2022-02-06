import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CoreModule } from '../core';
import { HeaderComponent, NavbarComponent, SidebarComponent, MainContentComponent, FooterComponent, ModalComponent } from '.';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';



@NgModule({
  declarations: [
    HeaderComponent,
    NavbarComponent,
    SidebarComponent,
    MainContentComponent,
    FooterComponent,
    ModalComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CoreModule,
    FontAwesomeModule
  ],
  exports:[
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CoreModule,
    HeaderComponent,
    NavbarComponent,
    SidebarComponent,
    MainContentComponent,
    FooterComponent,
    ModalComponent
  ]
})
export class SharedModule { }
