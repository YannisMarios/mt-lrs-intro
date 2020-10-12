import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Actions, createEffect, ofType } from '@ngrx/effects';

import * as fromApp from '../../store/app.reducer';
import * as UserActions from '../store/user.actions';
import { map, switchMap, tap, withLatestFrom } from 'rxjs/operators';
import { PageDto } from 'src/app/shared/Dtos/PageDto';
import { User } from '../user.model';

@Injectable()
export class UserEffects {
  fetchUsers$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(UserActions.fetchUsers),
      withLatestFrom(this.store.select('userState')),
      switchMap(([actionData, userState]) => {
        const response = this.http.post<PageDto<User>>(
          'https://localhost:44367/api/users',
          actionData.searchParamsDTO
        );

        return response;
      }),
      map((users) => {
        return UserActions.setUsers({ users });
      })
    );
  });

  fetchUser$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(UserActions.fetchUser),
      withLatestFrom(this.store.select('userState')),
      switchMap(([actionData, userState]) => {
        const response = this.http.get<User>(
          `https://localhost:44367/api/users/${actionData.id}`
        );

        return response;
      }),
      map((user) => {
        return UserActions.setUser({ user });
      })
    );
  });

  createUsers$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UserActions.createUser),
      switchMap((actionData) => {
        return this.http.post(
          'https://localhost:44367/api/users/add',
          actionData.user
        );
      }),
      map((actionData: number) => {
        return { type: 'DUMMY ' };
      })
    )
  );

  updateUsers$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(UserActions.updateUser),
      switchMap((actionData) => {
        return this.http.put(
          `https://localhost:44367/api/users/edit/${actionData.id}`,
          actionData.user
        );
      }),
      map((user) => {
        return UserActions.setUser({ user });
      })
    );
  });

  deleteUsers$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UserActions.deleteUser),
      switchMap((actionData) => {
        return this.http.delete(
          `https://localhost:44367/api/users/delete/${actionData.id}`
        );
      }),
      map((actionData: number) => {
        return { type: 'DUMMY ' };
      })
    )
  );

  constructor(
    private actions$: Actions,
    private http: HttpClient,
    private store: Store<fromApp.AppState>
  ) {}
}
