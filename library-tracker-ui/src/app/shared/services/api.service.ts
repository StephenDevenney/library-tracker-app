import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, switchMap } from 'rxjs/operators';
import { Globals } from '../classes/globals';
import { Config } from '../classes/config';
import { AuthService } from './auth.service';

@Injectable()
export class APIService {
    constructor(private globals: Globals,
                private http: HttpClient,
                private authService: AuthService) {}

    public async loadApplication(): Promise<any> {
        return await this.http.get('/assets/appsettings.json')
                        .pipe(map((res: any) => res))
                        .pipe(switchMap(async (res: Config) => {
                            this.globals.config.hubName = res.hubName;
                            this.globals.config.appApiUrl = res.appApiUrl;
                            this.globals.config.authApiUrl = res.authApiUrl;
                            this.globals.config.securityRedirectUrl = res.securityRedirectUrl;
                            this.globals.settings.theme = res.defaultTheme;
                            this.globals.currentPage = res.homePage;
                            this.globals.config.homePage = res.homePage;
                            this.globals.config.defaultTheme = res.defaultTheme;
                            
                            if(!this.authService.hasAuthToken()) {
                                return this.globals;
                            }
                            else
                                return await this.http.get(this.globals.config.appApiUrl + "security/user-settings").pipe(map(r => r)).toPromise();     
                        })).toPromise().catch((err: any) => {
                             this.globals.seriousErrorMessage = err;
                        }).then((res: any) => {
                            if(this.globals.seriousErrorMessage == "") {
                                if(res.user.isAuthenticated) {
                                    this.globals.isSignedIn = true;
                                    this.globals.user.userName = res.user.userName;
                                    this.globals.user.userRole = res.user.userRole;
                                    this.globals.user.isAuthenticated = res.user.isAuthenticated;
                                    
                                    this.globals.settings.appIdleSecs = res.appIdleSecs;
                                    this.globals.settings.navMinimised = res.navMinimised;
                                    this.globals.settings.theme = res.theme;
                                }
                                else
                                    this.authService.signOut();
                            }
                            else
                                this.authService.signOut();
                        });
    }
}

