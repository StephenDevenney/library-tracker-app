import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './modules/admin/admin-page/admin.component';
import { BooksComponent } from './modules/books/books-page/books.component';
import { ComicsComponent } from './modules/comics/comics-page/comics.component';

import { HomeComponent } from './modules/home/home-page/home.component';
import { SettingsComponent } from './modules/settings/settings-page/settings.component';
import { SignInComponent } from './modules/sign-in/sign-in-page/signin.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent, data: {page: 'home'} },
  { path: 'sign-in', component: SignInComponent, data: {page: 'sign-in'} },
  { path: 'settings', component: SettingsComponent, data: {page: 'settings'} },
  { path: 'admin', component: AdminComponent, data: {page: 'admin'} },
  { path: 'books', component: BooksComponent, data: {page: 'books'} },
  { path: 'comics', component: ComicsComponent, data: {page: 'comics'} },
  { path: '**', redirectTo:'sign-in', data: {page: 'sign-in'} }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
