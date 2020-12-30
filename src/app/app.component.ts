import { Component, OnDestroy, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Users } from './classes/users';
import { Router } from '@angular/router';
import { AuthenticationService } from './services/authentication.service';

/* istanbul ignore next */
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'lcp';
  name: any = '';
  currentUser: Users;
  isHeaderAllowed: boolean;
  isFooterAllowed: boolean;

  constructor(
    private location: Location,
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    this.location.onUrlChange(x => {
      const urlDelimitators = new RegExp(/[?//,;&:#$+=]/);
      this.name = x.slice(1).split(urlDelimitators)[0];
      this.setPartsAllowed();
    });
  }

  ngOnInit() {
  }

  ngOnDestroy() {
  }

  setPartsAllowed() {
    var confrouteary: any = this.router.config;
    var forbiddenPathsArray = ["", "**", "home", "login", "register"];

    if (confrouteary.length > 0) {
      confrouteary = confrouteary.filter((x: any) => {
        return !forbiddenPathsArray.includes(x.path);
      }).map((m: any) => m.path);
  
      for (var x = 0; x < confrouteary.length; x++) {
        if (this.name == confrouteary[x]) {
          this.isHeaderAllowed = true;
          this.isFooterAllowed = true;
        }
      }
    }
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }
}
