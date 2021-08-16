import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/modules/sharedModule';
import { SettingsComponent } from './settings-page/settings.component';
import { SettingsService } from './settings.service';

@NgModule({
  declarations: [
    SettingsComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    RouterModule
  ],
  providers: [
    SettingsService
  ]
})

export class SettingsModule { 
  static forRoot(): ModuleWithProviders<SettingsModule> {
    return {
      ngModule: SettingsModule
    }
  }
}
