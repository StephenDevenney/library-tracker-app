import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/modules/sharedModule';
import { BooksComponent } from './books-page/books.component';

@NgModule({
  declarations: [
    BooksComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    RouterModule
  ]
})

export class BooksModule { 
  static forRoot(): ModuleWithProviders<BooksModule> {
    return {
      ngModule: BooksModule
    }
  }
}
