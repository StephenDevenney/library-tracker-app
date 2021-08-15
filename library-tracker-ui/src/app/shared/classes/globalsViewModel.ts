import { Injectable } from '@angular/core';
import { User } from './user';
import { AppIdleSecs, Theme } from './user-settings';

@Injectable()
export class GlobalsViewModel {
    public user: User = new User;
    public theme: Theme = new Theme;
    public appIdleSecs: AppIdleSecs = new AppIdleSecs;
    public navMinimised: boolean = false;
}