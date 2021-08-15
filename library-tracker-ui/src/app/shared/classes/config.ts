import { Injectable } from '@angular/core';
import { Theme } from './user-settings';

@Injectable()
export class Config {
    public hubName: string = "";
    public appApiUrl: string = "";
    public authApiUrl: string = "";
    public securityRedirectUrl: string = "";
    public defaultTheme: Theme = new Theme;
}


