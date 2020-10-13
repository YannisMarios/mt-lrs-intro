import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { UserDetailsComponent } from './user-details/user-details.component';
import { UserListComponent } from './user-list/user-list.component';
import { UsersRoutingModule } from './users-routing.module';
import { UserFormComponent } from './user-form/user-form.component';
import { DeleteUserModalComponent } from './user-delete/user-delete-modal.component';

@NgModule({
  declarations: [
    UserListComponent,
    UserDetailsComponent,
    UserFormComponent,
    DeleteUserModalComponent,
  ],
  imports: [
    RouterModule,
    ReactiveFormsModule,
    SharedModule,
    UsersRoutingModule,
  ],
})
export class UsersModule {}
