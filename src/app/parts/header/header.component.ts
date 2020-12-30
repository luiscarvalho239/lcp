import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';
import { Users } from '@app/classes/users';
import { AuthenticationService } from '@app/services/authentication.service';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, AfterViewInit, OnDestroy {
  title = 'LCP';
  urlPage: string;
  events: string[] = [];
  events_adm: string[] = [];
  opened: boolean = false;
  opened_adm: boolean = false;
  isAdminPage: boolean = false;
  uName: Users;

  constructor(private authSrv: AuthenticationService, private router: Router, private location: Location) {
    this.location.onUrlChange(x => {
      const urlDelimitators = new RegExp(/[?//,;&:#$+=]/);
      this.urlPage = x.slice(1).split(urlDelimitators)[0];
      this.setAPageBool();
    });
  }

  ngOnInit(): void {
    this.setAPageBool();
    this.uName = JSON.parse(localStorage.getItem('currentUser'));
  }

  ngAfterViewInit() {
    this.opened = false;
    this.opened_adm = false;
  }

  ngOnDestroy() {
    this.opened = false;
    this.opened_adm = false;
  }

  setAPageBool() {
    if (this.location.path().toString().indexOf('admin') !== -1) {
      this.isAdminPage = true;
    } else {
      this.isAdminPage = false;
    }
  }

  logout() {
    this.authSrv.logout();
  }
}
