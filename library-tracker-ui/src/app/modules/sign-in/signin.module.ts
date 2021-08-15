import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/modules/sharedModule';
import { SignInComponent } from './sign-in-page/signin.component';
import { SignInService } from './signin.service';

@NgModule({
  declarations: [
    SignInComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    RouterModule
  ],
  providers: [
    SignInService
  ]
})

export class SignInModule { 
  static forRoot(): ModuleWithProviders<SignInModule> {
    return {
      ngModule: SignInModule
    }
  }
}
