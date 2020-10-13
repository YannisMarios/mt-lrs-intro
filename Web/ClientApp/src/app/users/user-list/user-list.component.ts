import {
  Component,
  OnDestroy,
  OnInit,
  ViewChild,
  AfterViewInit,
} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTable } from '@angular/material/table';
import { Store } from '@ngrx/store';
import { merge, Subscription } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { FormControl } from '@angular/forms';

import { User } from '../user.model';
import * as fromApp from '../../store/app.reducer';
import { DataTableSource } from 'src/app/shared/data-table/data-table-source';
import { PageDto } from 'src/app/shared/Dtos/PageDto';
import * as UserActions from '../../users/store/user.actions';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { DeleteUserModalComponent } from '../user-delete/user-delete-modal.component';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
})
export class UserListComponent implements AfterViewInit, OnInit, OnDestroy {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatTable) table: MatTable<User>;

  private usersChangedSubscription: Subscription;
  public readonly filterControl = new FormControl('');
  public totalCount = 0;
  public currentPage = 0;
  dataSource = new DataTableSource<User>();

  displayedColumns = [
    'id',
    'userTitle',
    'name',
    'surname',
    'emailAddress',
    'userType',
    'action',
  ];

  ngOnInit(): void {
    this.usersChangedSubscription = this.store
      .select('userState')
      .pipe(map((userState) => userState.users))
      .subscribe((page: PageDto<User>) => {
        this.totalCount = page.totalCount;
        this.currentPage = page.currentPage;
        this.dataSource.data = page.items;
      });
  }

  ngOnDestroy() {
    this.usersChangedSubscription.unsubscribe();
  }

  ngAfterViewInit() {
    this.table.dataSource = this.dataSource;

    merge(this.paginator.page, this.filterControl.valueChanges)
      .pipe(
        startWith({}),
        map(() => {
          this.searchAction(
            this.filterControl.value,
            this.paginator.pageIndex,
            this.paginator.pageSize
          );
        })
      )
      .subscribe(() => console.log('lalala'));
  }

  searchAction(searchString = '', pageIndex = 0, pageSize = 5) {
    this.store.dispatch(
      UserActions.fetchUsers({
        searchParamsDTO: { searchString, pageIndex, pageSize },
      })
    );
  }

  onEdit() {
    this.router.navigate(['edit'], { relativeTo: this.route });
  }

  onDelete(user: User) {
    const dialogRef = this.dialog.open(DeleteUserModalComponent, {
      width: '400px',
      data: {
        user,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if(result) {
        this.store.dispatch(UserActions.deleteUser({ id: user.id }));
        this.searchAction();
      }
    });
  }

  constructor(
    private store: Store<fromApp.AppState>,
    private route: ActivatedRoute,
    private router: Router,
    public dialog: MatDialog
  ) {}
}
