import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Globals, NavPage } from '../classes/globals';

@Injectable()
export class AuthService {

    constructor(private router: Router,
                private globals: Globals){}

    public hasAuthToken(): boolean {
        var token = this.getToken();

        if(!token)
            return false;

        return true;
    }

    public getToken(): string | null {
        return localStorage.getItem("auth_token");
    }

    public getCurrentPage(): string | null {
        return localStorage.getItem("current_page");
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

    public async updateCurrentPage(page: NavPage): Promise<void> {
        localStorage.removeItem("current_page");
        localStorage.setItem("current_page", page.navMenuRoute);
    }
}