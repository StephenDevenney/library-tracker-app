import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/modules/sharedModule';
import { ComicsComponent } from './comics-page/comics.component';

@NgModule({
  declarations: [
    ComicsComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    RouterModule
  ]
})

export class ComicsModule { 
  static forRoot(): ModuleWithProviders<ComicsModule> {
    return {
      ngModule: ComicsModule
    }
  }
}
