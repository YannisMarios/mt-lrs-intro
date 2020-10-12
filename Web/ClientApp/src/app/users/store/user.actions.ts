import { createAction, props } from '@ngrx/store';
import { PageDto } from 'src/app/shared/Dtos/PageDto';
import { SearchUsersParamsDto, User } from '../user.model';

export const setUsers = createAction(
  '[User] Set Users',
  props<{
    users: PageDto<User>;
  }>()
);

export const fetchUsers = createAction(
  '[User] Fetch Users',
  props<{
    searchParamsDTO: SearchUsersParamsDto;
  }>()
);

export const fetchUser = createAction(
  '[User] Fetch User',
  props<{
    id: number;
  }>()
);

export const setUser = createAction(
  '[User] Set User',
  props<{
    user: User;
  }>()
);

export const createUser = createAction(
  '[User] Create User',
  props<{
    user: User;
  }>()
);

export const updateUser = createAction(
  '[User] Update User',
  props<{
    id: number;
    user: User;
  }>()
);

export const deleteUser = createAction(
  '[User] Delete User',
  props<{
    id: number;
  }>()
);
