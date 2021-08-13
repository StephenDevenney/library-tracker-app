import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/shared/components/base.component';

@Component({
  selector: 'home',
  templateUrl: './home.component.html'
})
export class HomeComponent extends BaseComponent implements OnInit {

  constructor(private injector: Injector) {
    super(injector);
  }

  ngOnInit(): void {
  }
}
