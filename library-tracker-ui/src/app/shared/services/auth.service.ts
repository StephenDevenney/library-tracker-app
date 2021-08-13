import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Globals } from '../classes/globals';
import { APIService } from './api.service';

@Injectable()
export class AuthService {

    constructor(private router: Router,
                private apiService: APIService,
                private globals: Globals){}

    public isAuthenticated(): boolean {
        var token = this.getToken();

        if(!token){
            return false;
            // TODO: security redirect;
        }

        return true;
    }

    public getToken(): string | null {
        return localStorage.getItem("auth_token");
    }

    public emptyLocalStorage(): void {
        this.globals.isSignedIn = false;
        localStorage.removeItem("auth_token");
        localStorage.removeItem("current_page");
    }

    public signOut(): void {
        this.emptyLocalStorage();
        // TODO: security redirect;
    }

    public async authenticate(): Promise<any> {
        
    }
}