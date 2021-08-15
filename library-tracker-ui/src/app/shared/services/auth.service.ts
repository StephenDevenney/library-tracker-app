import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Globals } from '../classes/globals';
import { APIService } from './api.service';

@Injectable()
export class AuthService {

    constructor(private router: Router,
                private globals: Globals){}

    public isAuthenticated(): boolean {
        var token = this.getToken();

        if(!token)
            return false;

        return true;
    }

    public getToken(): string | null {
        return localStorage.getItem("auth_token");
    }

    public async emptyLocalStorage(): Promise<void> {
        this.globals.isSignedIn = false;
        this.globals.seriousErrorMessage = "";
        localStorage.removeItem("auth_token");
        localStorage.removeItem("current_page");
    }

    public async signOut(): Promise<void> {
        await this.emptyLocalStorage();
        await this.router.navigate([this.globals.config.securityRedirectUrl]);
    }

    public async updateAuthToken(token: string): Promise<void> {
        localStorage.removeItem("auth_token");
        localStorage.setItem("auth_token", "Bearer " + token);
    }
}