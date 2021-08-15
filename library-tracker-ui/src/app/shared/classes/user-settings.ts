import { Injectable } from '@angular/core';

@Injectable()
export class UserSettings {
    public theme: Theme = new Theme;
    public navMinimised: boolean = false;
    public appIdleSecs: number = 0;
}

@Injectable()
export class Theme {
    public themeName: string = "";
    public themeClassName: string = "";
}


