import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Users } from '@app/classes/users';
import { UsersService } from '@app/services/users.service';
import { Subscription } from 'rxjs';

/* istanbul ignore next */
@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit, OnDestroy {
  id: number;
  dataUsers: Users[];
  private sub: Subscription;

  constructor(private myr: ActivatedRoute, private usersSrv: UsersService) { 
    this.sub = this.myr.params.subscribe((p: Params) => {
      this.id = +p['id'] || -1;
    });
  }

  ngOnInit(): void {
    this.loadDataUsers(this.id);
  }

  loadDataUsers(id = -1) {
    this.usersSrv.getUsers().subscribe((r: Users[]) => {
      this.dataUsers = (id <= -1) ? r : r.filter(x => x.id == id);
    }, (err) => console.log(err));
  }

  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }
}
