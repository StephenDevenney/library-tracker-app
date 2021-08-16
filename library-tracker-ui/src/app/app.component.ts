import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Globals } from './shared/classes/globals';
import { APIService } from './shared/services/api.service';
import { AuthService } from './shared/services/auth.service';
import { SharedService } from './shared/services/shared.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  public title = 'Library-Tracker';
  public isLoaded = false;

  constructor(private apiService: APIService,
              public globals: Globals,
              private sharedService: SharedService,
              private authService: AuthService,
              private route: ActivatedRoute) {
                
                this.loadApplication();
              }

    public async loadApplication(): Promise<void> {
      await this.apiService.loadApplication().then(async () => {
        this.isLoaded = true;
        if(this.globals.isSignedIn) {
          await this.setRoute();
          await this.sharedService.navToPage(this.globals.currentPage);
        }
      }).catch((err) => {}); 
    }

    private async setRoute(): Promise<void> {
      let cp = this.authService.getCurrentPage();
      if(cp != null)
        this.globals.currentPage.navMenuRoute = cp;
    }
}
