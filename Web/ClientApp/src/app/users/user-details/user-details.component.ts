import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { map } from 'rxjs/operators';

import * as fromApp from '../../store/app.reducer';
import * as UserActions from '../../users/store/user.actions';
import { User } from '../user.model';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css'],
})
export class UserDetailsComponent implements OnInit, OnDestroy {
  private userChangedSubscription: Subscription;
  id: number;
  user: User;

  ngOnInit(): void {
    this.route.params
      .pipe(
        map((params) => +params['id']),
        map((id: number) => {
          this.id = id;
          this.store.dispatch(UserActions.fetchUser({ id }));
        })
      )
      .subscribe();

    this.userChangedSubscription = this.store
      .select('userState')
      .pipe(map((userState) => userState.user))
      .subscribe((user: User) => {
        this.user = user;
      });
  }

  ngOnDestroy() {
    this.userChangedSubscription.unsubscribe();
  }

  onBack() {
    this.router.navigate(['/users']);
  }

  constructor(
    private store: Store<fromApp.AppState>,
    private route: ActivatedRoute,
    private router: Router
  ) {}
}
