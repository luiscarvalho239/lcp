import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminAuthGuard } from './helpers/adminauth.guard';
import { AuthGuard } from './helpers/auth.guard';
import { AdminComponent } from './pages/admin/admin.component';
import { AdminNewsComponent } from './pages/admin/adm_pages/news/news.component';
import { AdminUsersComponent } from './pages/admin/adm_pages/users/users.component';
import { AdminVideosComponent } from './pages/admin/adm_pages/videos/videos.component';
import { LoginComponent } from './pages/auth/login/login.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import { HomeComponent } from './pages/home/home.component';
import { ListsComponent } from './pages/lists/lists.component';
import { MainComponent } from './pages/main/main.component';
import { NewsComponent } from './pages/news/news.component';
import { NewsdetComponent } from './pages/news/newsdet/newsdet.component';
import { UsersComponent } from './pages/users/users.component';
import { VideosComponent } from './pages/videos/videos.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full', canActivate: [AuthGuard] },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'admin',
    component: AdminComponent,
    children: [
      { path: '', redirectTo: '/admin', pathMatch: 'full', canActivateChild: [AdminAuthGuard] },
      { path: 'users', component: AdminUsersComponent },
      { path: 'news', component: AdminNewsComponent },
      { path: 'videos', component: AdminVideosComponent },
      { path: '**', redirectTo: '/admin', pathMatch: 'full' }
    ],
    canActivate: [AdminAuthGuard]
  },
  { path: 'main', component: MainComponent },
  { path: 'news', component: NewsComponent },
  { path: 'news/:id', component: NewsdetComponent },
  { path: 'users', component: UsersComponent },
  { path: 'users/:id', component: UsersComponent },
  { path: 'videos', component: VideosComponent },
  { path: 'lists', component: ListsComponent },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: false })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
