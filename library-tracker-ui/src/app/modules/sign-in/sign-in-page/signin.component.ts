import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/shared/components/base.component';

@Component({
  selector: 'sign-in',
  templateUrl: './signin.component.html'
})
export class SignInComponent extends BaseComponent implements OnInit {
  public userName: string = "";

  constructor(private injector: Injector) {
    super(injector);
  }

  ngOnInit(): void {
    console.log(this.globals);
  }
}
