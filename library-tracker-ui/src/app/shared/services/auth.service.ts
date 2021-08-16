import { Injectable } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Globals, NavPage } from '../classes/globals';

@Injectable()
export class AuthService {

    constructor(private router: Router,
                private globals: Globals,
                private titleService: Title){}

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
        localStorage.removeItem("auth_token");
        localStorage.removeItem("current_page");
    }

    public async revertSettings(): Promise<void> {
        this.globals.isSignedIn = false;
        this.globals.seriousErrorMessage = "";
        this.globals.currentPage = this.globals.config.homePage;
        this.globals.previousPage = this.globals.config.homePage;
        this.globals.settings.theme = this.globals.config.defaultTheme;
        this.globals.user.token = "";
        this.globals.user.isAuthenticated = false;
        this.titleService.setTitle(this.globals.config.hubName + " - Sign In");
    }

    public async signOut(): Promise<void> {
        await this.emptyLocalStorage();
        await this.revertSettings();
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