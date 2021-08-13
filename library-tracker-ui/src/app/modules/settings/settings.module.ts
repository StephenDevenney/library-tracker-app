import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/modules/sharedModule';
import { SettingsComponent } from './settings-page/settings.component';

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
  ]
})

export class SettingsModule { 
  static forRoot(): ModuleWithProviders<SettingsModule> {
    return {
      ngModule: SettingsModule
    }
  }
}
