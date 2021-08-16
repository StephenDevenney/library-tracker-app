import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Globals } from './shared/classes/globals';
import { APIService } from './shared/services/api.service';
import { AuthService } from './shared/services/auth.service';
import { SharedService } from './shared/services/shared.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  public title = 'Library Tracker';
  public isLoaded = false;

  constructor(private apiService: APIService,
              public globals: Globals,
              private sharedService: SharedService,
              private authService: AuthService,
              private route: ActivatedRoute,
              private titleService: Title) {}

    async ngOnInit(): Promise<void> {
      await this.loadApplication();
    }

    public async loadApplication(): Promise<void> {
      this.titleService.setTitle(this.title);
      await this.apiService.loadApplication().then(async () => {
        this.isLoaded = true;
        if(this.globals.isSignedIn) {
          await this.setRoute();
          await this.sharedService.navToPage(this.globals.currentPage);
          console.log(this.globals);
        }
      }).catch((err) => {}); 
    }

    private async setRoute(): Promise<void> {
      let cp = this.authService.getCurrentPage();
      if(cp != null)
        this.globals.currentPage.navMenuRoute = cp;
    }
}
