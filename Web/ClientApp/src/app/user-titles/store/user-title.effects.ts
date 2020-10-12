import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Actions, createEffect, ofType } from '@ngrx/effects';

import * as fromApp from '../../store/app.reducer';
import * as UserTitleActions from '../store/user-title.actions';
import { map, switchMap, withLatestFrom } from 'rxjs/operators';
import { UserTitle } from '../user-title.model';

@Injectable()
export class UserTitleEffects {
  fetchUsersTitles$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(UserTitleActions.fetchUserTitles),
      withLatestFrom(this.store.select('userTitles')),
      switchMap(([actionData, userTitlesState]) => {
        const response = this.http.get<UserTitle[]>(
          'https://localhost:44367/api/user-titles'
        );

        return response;
      }),
      map((userTitles) => {
        return UserTitleActions.setUserTitles({ userTitles });
      })
    );
  });

  constructor(
    private actions$: Actions,
    private http: HttpClient,
    private store: Store<fromApp.AppState>
  ) {}
}
