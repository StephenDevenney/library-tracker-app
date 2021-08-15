import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './modules/home/home-page/home.component';
import { SettingsComponent } from './modules/settings/settings-page/settings.component';
import { SignInComponent } from './modules/sign-in/sign-in-page/signin.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent, data: {page: 'home'} },
  { path: 'sign-in', component: SignInComponent, data: {page: 'sign-in'} },
  { path: 'settings', component: SettingsComponent, data: {page: 'settings'} },
  { path: '**', redirectTo:'sign-in', data: {page: 'sign-in'} }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
