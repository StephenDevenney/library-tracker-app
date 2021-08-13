import { Injectable } from '@angular/core';

@Injectable()
export class Config {
    public hubName: string = "";
    public appApiUrl: string = "";
    public authApiUrl: string = "";
    public securityRedirectUrl: string = "";
}


