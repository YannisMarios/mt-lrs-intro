import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Store } from '@ngrx/store';
import { User } from '../user.model';

import * as fromApp from '../../store/app.reducer';
import * as UserActions from '../store/user.actions';
import { Actions, ofType } from '@ngrx/effects';
import { map, switchMap, take } from 'rxjs/operators';
import { of } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class UserResolverService implements Resolve<{ user: User }> {
  constructor(
    private store: Store<fromApp.AppState>,
    private actions$: Actions
  ) {}

  resolve(route: ActivatedRouteSnapshot) {
    return this.store.select('userState').pipe(
      take(1),
      map((userState) => {
        return userState.user;
      }),
      switchMap((user) => {
        if (!user && route.params['id']) {
          this.store.dispatch(
            UserActions.fetchUser({ id: +route.params['id'] })
          );
          return this.actions$.pipe(ofType(UserActions.setUser), take(1));
        } else {
          return of({ user });
        }
      })
    );
  }
}
