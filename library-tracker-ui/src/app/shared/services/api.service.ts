import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, switchMap } from 'rxjs/operators';
import { Globals } from '../classes/globals';
import { Config } from '../classes/config';

@Injectable()
export class APIService {
    constructor(private globals: Globals,
                private http: HttpClient) {}

    public async loadApplication(): Promise<any> {
        return this.http.get('/assets/appsettings.json')
                        .pipe(map((res: any) => res))
                        .pipe(switchMap((res: Config) => {
                            this.globals.config.hubName = res.hubName;
                            this.globals.config.appApiUrl = res.appApiUrl;
                            this.globals.config.authApiUrl = res.appApiUrl;
                            this.globals.config.securityRedirectUrl = res.securityRedirectUrl;
                            
                            /* 
                                TODO: Check localStorage for jwtToken here.
                            */

                            return this.http.get(this.globals.config.authApiUrl + "security/config-settings").pipe(map(r => r));
                        })).toPromise().catch((err: any) => {
                             this.globals.seriousErrorMessage = err;
                        }).then((res: any) => {
                            if(this.globals.seriousErrorMessage == "") {
                                this.globals.isSignedIn = true;
                                /* 
                                TODO: update localStorage with jwtToken here.
                                */

                                if(res.user.isAuthenticated) {
                                    this.globals.user.userName = res.user.userName;
                                    this.globals.user.userRole = res.user.userRole;
                                    this.globals.user.isAuthenticated = res.user.isAuthenticated;

                                    this.globals.settings.appIdleSecs = res.appIdleSecs;
                                    this.globals.settings.navMinimised = res.navMinimised;
                                    this.globals.settings.theme = res.theme;
                                }
                            }
                        });
    }
}

