import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgxUiLoaderModule, NgxUiLoaderConfig, POSITION, SPINNER, PB_DIRECTION } from 'ngx-ui-loader';
import { APIInterceptor } from './shared/classes/api.interceptor';
import { AuthService } from './shared/services/auth.service';
import { APIService } from './shared/services/api.service';
import { SharedModule } from './shared/modules/sharedModule';
import { RedirectToComponent } from './shared/components/redirect-to/redirectTo.component';
import { LoadingService } from './shared/services/loading.service';
import { MessageService } from 'primeng/api';
import { LayoutModule } from './layout/layout.module';
import { HomeModule } from './modules/home/home.module';
import { SignInModule } from './modules/sign-in/signin.module';
import { SettingsModule } from './modules/settings/settings.module';
import { SharedService } from './shared/services/shared.service';
import { AdminModule } from './modules/admin/admin.module';
import { BooksModule } from './modules/books/books.module';
import { ComicsModule } from './modules/comics/comics.module';

/*
  bgs = bottomRight Small loader
  fgs = main center loader
  pb = top bar loader
*/
const ngxUiLoaderConfig: NgxUiLoaderConfig = {
  bgsColor: '#66b3ff',
  bgsPosition: POSITION.bottomRight,
  bgsSize: 100,
  bgsType: SPINNER.wanderingCubes,
  bgsOpacity: 0.8,
  fgsColor: '#66b3ff',
  fgsPosition: POSITION.centerCenter,
  fgsType: SPINNER.cubeGrid,
  fgsSize: 150,
  pbColor: '#66b3ff',
  pbDirection: PB_DIRECTION.leftToRight,
  pbThickness: 20
};

@NgModule({
  declarations: [
    AppComponent,
    RedirectToComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LayoutModule,
    HomeModule,
    SignInModule,
    SettingsModule,
    AdminModule,
    BooksModule,
    ComicsModule,
    SharedModule,
    HttpClientModule,
    NgxUiLoaderModule.forRoot(ngxUiLoaderConfig)
  ],
  providers: [
    AuthService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: APIInterceptor,
      multi: true,
    },
    APIService ,
    MessageService,
    LoadingService,
    SharedService
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
