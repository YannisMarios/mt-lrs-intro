import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Actions, createEffect, ofType } from '@ngrx/effects';

import * as fromApp from '../../store/app.reducer';
import * as UserTypeActions from './user-type.actions';
import { map, switchMap, withLatestFrom } from 'rxjs/operators';
import { UserType } from '../user-type.model';

@Injectable()
export class UserTypeEffects {
  fetchUsersTypes$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(UserTypeActions.fetchUserTypes),
      withLatestFrom(this.store.select('userTypes')),
      switchMap(([actionData, userTypesState]) => {
        const response = this.http.get<UserType[]>(
          'https://localhost:44367/api/user-types'
        );

        return response;
      }),
      map((userTypes) => {
        return UserTypeActions.setUserTypes({ userTypes });
      })
    );
  });

  constructor(
    private actions$: Actions,
    private http: HttpClient,
    private store: Store<fromApp.AppState>
  ) {}
}
