import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Globals } from '../classes/globals';
import { TableModule } from 'primeng/table';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { ToastModule } from 'primeng/toast'
import { MessageService } from 'primeng/api';
import { MultiSelectModule } from 'primeng/multiselect';
import { DropdownModule } from 'primeng/dropdown';
import { DialogModule } from 'primeng/dialog';
import { InputNumberModule } from 'primeng/inputnumber';
import { NgxUiLoaderModule } from 'ngx-ui-loader';
import { InputSwitchModule } from 'primeng/inputswitch';
import { ButtonModule } from 'primeng/button';
import { TabViewModule } from 'primeng/tabview';
import { ListboxModule } from 'primeng/listbox';
import { InputTextModule } from 'primeng/inputtext';

@NgModule({
  imports: [
    CommonModule,
    NgxUiLoaderModule,
    InputSwitchModule,
    ButtonModule,
    TabViewModule
  ],
  declarations: [
    
  ],
  exports: [
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    TableModule,
    MultiSelectModule,
    DropdownModule,
    DialogModule,
    InputNumberModule,
    ToastModule,
    ButtonModule,
    TabViewModule,
    ListboxModule,
    InputTextModule
  ],
  providers: [
    Globals,
    MessageService,
    MultiSelectModule
  ]
})
export class SharedModule { 
  static forRoot(): ModuleWithProviders<SharedModule> {
    return {
      ngModule: SharedModule
    }
  }
}
