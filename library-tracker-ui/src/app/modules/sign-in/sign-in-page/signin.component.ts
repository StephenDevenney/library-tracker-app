import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/shared/components/base.component';

@Component({
  selector: 'sign-in',
  templateUrl: './signin.component.html'
})
export class SignInComponent extends BaseComponent implements OnInit {

  constructor(private injector: Injector) {
    super(injector);
  }

  ngOnInit(): void {
  }
}
