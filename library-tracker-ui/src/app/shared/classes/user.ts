import { Injectable } from '@angular/core';

@Injectable()
export class User {
    public userName: string = "";
    public Token: string = "";
    public userRole: UserRole = new UserRole;
    public isAuthenticated: boolean = false;
}

export class UserRole {
    public userRoleId: number = 0;
    public userRoleName: string = "";
}


