import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { map } from 'rxjs/operators';
import { DateAdapter, MAT_DATE_FORMATS } from '@angular/material/core';

import * as fromApp from '../../store/app.reducer';
import * as UserActions from '../store/user.actions';
import * as UserTitleActions from '../../user-titles/store/user-title.actions';
import * as UserTypeActions from '../../user-types/store/user-type.actions';
import {
  AppDateAdapter,
  APP_DATE_FORMATS,
} from '../../shared/helpers/format.datepickers';
import { User } from '../user.model';
import { UserTitle } from 'src/app/user-titles/user-title.model';
import { UserType } from 'src/app/user-types/user-type.model';
import { DeleteUserModalComponent } from 'src/app/users/user-delete/user-delete-modal.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css'],
  providers: [
    { provide: DateAdapter, useClass: AppDateAdapter },
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS },
  ],
})
export class UserFormComponent implements OnInit {
  private userChangedSubscription: Subscription;
  private userTitlesChangedSubscription: Subscription;
  private userTypesChangedSubscription: Subscription;
  form: FormGroup;
  id: number;
  user: User = {
    name: '',
    surname: '',
    birthDate: new Date(),
    userTypeId: null,
    userTitleId: null,
    emailAddress: '',
    isActive: true,
  };
  userTitles: UserTitle[];
  userTypes: UserType[];
  editMode = false;
  minDate: Date;
  maxDate: Date;

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.id = +params['id'];
      this.editMode = params['id'] != null;
    });
    this.fetchDropDownData();
    this.initForm();
  }

  private fetchDropDownData() {
    this.store.dispatch(UserTitleActions.fetchUserTitles());
    this.store.dispatch(UserTypeActions.fetchUserTypes());

    this.userTitlesChangedSubscription = this.store
      .select('userTitles')
      .pipe(map((usersTitlesState) => usersTitlesState.userTitles))
      .subscribe((userTitles: UserTitle[]) => {
        this.userTitles = userTitles;
      });

    this.userTypesChangedSubscription = this.store
      .select('userTypes')
      .pipe(map((usersTypesState) => usersTypesState.userTypes))
      .subscribe((userTypes: UserType[]) => {
        this.userTypes = userTypes;
      });
  }

  private initForm() {
    if (this.editMode && !this.user.id) {
      console.log('editComponent')
      this.store.dispatch(UserActions.fetchUser({ id: this.id }));
      this.userChangedSubscription = this.store
        .select('userState')
        .pipe(map((userState) => userState.user))
        .subscribe((data: User) => {
          if (data) {
            this.user = data;
          }
        });
    }

    this.form = new FormGroup({
      name: new FormControl(this.user.name, [Validators.required]),
      surname: new FormControl(this.user.surname, [Validators.required]),
      birthDate: new FormControl(this.user.birthDate, [Validators.required]),
      userTypeId: new FormControl(this.user.userTypeId, [Validators.required]),
      userTitleId: new FormControl(this.user.userTitleId, [
        Validators.required,
      ]),
      emailAddress: new FormControl(this.user.emailAddress, [
        Validators.required,
        Validators.email,
      ]),
      isActive: new FormControl(this.user.isActive, null),
    });
  }

  ngOnDestroy() {
    if (this.editMode) {
      this.userChangedSubscription.unsubscribe();
    }

    this.userTitlesChangedSubscription.unsubscribe();
    this.userTypesChangedSubscription.unsubscribe();
  }

  onBack() {
    this.router.navigate(['/users']);
  }

  onSubmit() {
    if (this.form.valid) {
      if (this.editMode) {
        this.store.dispatch(
          UserActions.updateUser({ id: this.id, user: this.form.value })
        );
      } else {
        this.store.dispatch(UserActions.createUser({ user: this.form.value }));
      }
      this.onBack();
    }
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(DeleteUserModalComponent, {
      width: '400px',
      data: {
        user: this.user,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if(result) {
        this.store.dispatch(UserActions.deleteUser({ id: this.id }));
      }
      this.onBack();
    });
  }

  constructor(
    private store: Store<fromApp.AppState>,
    private route: ActivatedRoute,
    private router: Router,
    public dialog: MatDialog
  ) {
    const currentYear = new Date().getFullYear();
    this.minDate = new Date(currentYear - 100, 0, 1);
    this.maxDate = new Date();
  }
}
