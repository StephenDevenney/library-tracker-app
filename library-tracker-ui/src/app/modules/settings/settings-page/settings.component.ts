import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/shared/components/base.component';

@Component({
  selector: 'settings',
  templateUrl: './settings.component.html'
})
export class SettingsComponent extends BaseComponent implements OnInit {

  constructor(private injector: Injector) {
    super(injector);
  }

  ngOnInit(): void {
  }
}
