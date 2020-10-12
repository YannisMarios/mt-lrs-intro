import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserDetailsComponent } from './user-details/user-details.component';
import { UserFormComponent } from './user-form/user-form.component';
import { UserResolverService } from './user-form/user-resolver.service';
import { UserListComponent } from './user-list/user-list.component';

const routes: Routes = [
  {
    path: '',
    component: UserListComponent,
  },
  {
    path: 'add',
    component: UserFormComponent,
  },
  {
    path: ':id',
    component: UserDetailsComponent,
    resolve: [UserResolverService],
  },
  {
    path: ':id/edit',
    component: UserFormComponent,
    resolve: [UserResolverService],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UsersRoutingModule {}
