import { Injectable } from '@angular/core';
import { Config } from './config';
import { User } from './user';
import { UserSettings } from './user-settings';

@Injectable()
export class Globals {
    public config: Config = new Config;
    public user: User = new User;
    public settings: UserSettings = new UserSettings;
    public isSignedIn: boolean = false;
    public seriousErrorMessage: string = "";
    public previousPage: NavPage = new NavPage;
    public currentPage: NavPage = new NavPage;
}

export class NavPage {
    public navMenuName: string = "";
    public navMenuTitle: string = "";
    public navMenuRoute: string = "";
} 