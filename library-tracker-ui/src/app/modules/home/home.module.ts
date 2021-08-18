import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/modules/sharedModule';
import { HomeComponent } from './home-page/home.component';
import { HomeService } from './home.service';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    RouterModule
  ],
  providers: [
    HomeService
  ]
})

export class HomeModule { 
  static forRoot(): ModuleWithProviders<HomeModule> {
    return {
      ngModule: HomeModule
    }
  }
}
