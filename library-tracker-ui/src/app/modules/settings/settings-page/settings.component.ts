import { HttpErrorResponse } from '@angular/common/http';
import { Component, Injector, OnInit } from '@angular/core';
import { AppIdleSecs } from 'src/app/shared/classes/user-settings';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { AuthService } from 'src/app/shared/services/auth.service';
import { SharedService } from 'src/app/shared/services/shared.service';
import { SettingsService } from '../settings.service';

@Component({
  selector: 'settings',
  templateUrl: './settings.component.html'
})
export class SettingsComponent extends BaseComponent implements OnInit {

  public isLoaded: boolean = false;
  public appIdleSecsEnum: Array<AppIdleSecs> = new Array<AppIdleSecs>();
  constructor(private injector: Injector,
              private settingsService: SettingsService,
              private sharedService: SharedService,
              private authService: AuthService) {
    super(injector);
  }

  async ngOnInit(): Promise<void> {
    await this.getAppIdleSecsEnum();
    this.isLoaded = true;
  }

  public async appIdleTimeChanged(e: { originalEvent: MouseEvent, value: AppIdleSecs }): Promise<void> {
    this.globals.settings.appIdleSecs = e.value;
    await this.sharedService.saveSettings();
  }

  public async getAppIdleSecsEnum(): Promise<void> {
    await this.settingsService.getAppIdleSecs().catch((err: HttpErrorResponse) => {
      this.messageService.add({severity:'error', summary:'Error', detail:'Failed to get app idle times.', life: 2600 });
    }).then((res: Array<AppIdleSecs>) => {
      this.appIdleSecsEnum = res;
    });
  }

  public async logOutUser(): Promise<void> {
    this.authService.signOut();
  }
}
