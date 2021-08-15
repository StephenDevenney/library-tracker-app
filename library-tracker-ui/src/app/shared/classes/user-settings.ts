import { Injectable } from '@angular/core';

@Injectable()
export class UserSettings {
    public theme: Theme = new Theme;
    public navMinimised: boolean = false;
    public appIdleSecs: AppIdleSecs = new AppIdleSecs;
}

@Injectable()
export class Theme {
    public themeId: number = 0;
    public themeName: string = "";
    public themeClassName: string = "";
}

@Injectable()
export class AppIdleSecs {
    public idleTime: number = 0;
    public description: string = "";
}


