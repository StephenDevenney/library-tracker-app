import { HttpErrorResponse } from '@angular/common/http';
import { Component, Injector, OnInit } from '@angular/core';
import { User } from 'src/app/shared/classes/user';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { APIService } from 'src/app/shared/services/api.service';
import { AuthService } from 'src/app/shared/services/auth.service';
import { SharedService } from 'src/app/shared/services/shared.service';
import { SignInService } from '../signin.service';

@Component({
  selector: 'sign-in',
  templateUrl: './signin.component.html'
})
export class SignInComponent extends BaseComponent implements OnInit {
  public userName: string = "";

  constructor(private injector: Injector,
            private signInService: SignInService,
            private authService: AuthService,
            private apiService: APIService,
            private sharedService: SharedService) {
    super(injector);
  }

  ngOnInit(): void {
    console.log(this.globals);
  }

  public async checkUserName(): Promise<void> {
    this.loader.start();
    await this.signInService.authenticate(this.userName).catch((err: HttpErrorResponse) => {
      this.loader.stop();
    }).then(async (res: User) => {
      if(typeof(res) != "undefined" && res != null){
        await this.authService.updateAuthToken(res.token);
        await this.apiService.loadApplication();
        await this.sharedService.navToPage(this.globals.currentPage);
      }
      else 
        this.messageService.add({ severity:'info', summary:'Username not found', detail:'Create an account first.', life: 2600 });

      this.loader.stop();
    });
  }

  
}
