import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { Globals } from './shared/classes/globals';
import { APIService } from './shared/services/api.service';
import { AuthService } from './shared/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  public title = 'Library-Tracker';
  public isLoaded = false;

  constructor(private apiService: APIService,
              public globals: Globals,
              private titleService: Title,
              private router: Router,
              private route: ActivatedRoute) {
                
                this.loadApplication();
              }

    public async loadApplication() {
      await this.apiService.loadApplication().then(() => {
        this.isLoaded = true;
        this.router.navigate([this.globals.previousPage.navMenuRoute]);
        this.titleService.setTitle(this.globals.config.hubName + " - " + this.globals.previousPage.navMenuName);
      }).catch((err) => {});
      
    }
}
