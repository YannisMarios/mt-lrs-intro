import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { MatDialog } from '@angular/material/dialog';

import * as fromApp from '../../store/app.reducer';
import * as UserActions from '../store/user.actions';
import { catchError, map, switchMap, tap, withLatestFrom } from 'rxjs/operators';
import { PageDto } from 'src/app/shared/Dtos/PageDto';
import { User } from '../user.model';
import { ErrorModalComponent } from 'src/app/shared/error-modal/error-modal.component';
import { of } from 'rxjs';
import { Router } from '@angular/router';


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
        )
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
      switchMap((actionData) => {
        return this.http.get<User>(
          `https://localhost:44367/api/users/${actionData.id}`
        )
        .pipe(
          map((user) => {
            return UserActions.setUser({ user });
          }),
          catchError((error: HttpErrorResponse) => {
            this.handleError(error)
            return of(UserActions.setUser({ user: null }));
        }))
      }),
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
        )
        .pipe(
          map((user) => {
            return UserActions.setUser({ user });
          }),
          catchError((error: HttpErrorResponse) => {
            this.handleError(error)
            return of(UserActions.setUser({ user: null }));
        }))
      })
    );
  });

  deleteUsers$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UserActions.deleteUser),
      switchMap((actionData) => {
        return this.http.delete(
          `https://localhost:44367/api/users/delete/${actionData.id}`
        )
        .pipe(
          map(() => {
            return { type: 'DUMMY ' };
          }),
          catchError((error: HttpErrorResponse) => {
            this.handleError(error)
            return of(UserActions.setUser({ user: null }));
        }))
      })
    )
  );

  handleError = (error: HttpErrorResponse) => {
    if(this.dialog.openDialogs.length === 0) {
      const dialogRef = this.dialog.open(ErrorModalComponent, {
        width: '400px',
        data: {
          title: 'An error has ocurred',
          message: error.error,
        },
      });

      dialogRef.afterClosed().subscribe((result) => {
        this.router.navigate(['/users'])
      });
    }

  }

  constructor(
    private actions$: Actions,
    private http: HttpClient,
    private store: Store<fromApp.AppState>,
    private router: Router,
    public dialog: MatDialog
  ) {}
}
