import { createAction, props } from '@ngrx/store';
import { UserType } from '../user-type.model';

export const setUserTypes = createAction(
  '[UserTypes] Set UserTypes',
  props<{
    userTypes: UserType[];
  }>()
);

export const fetchUserTypes = createAction('[UserTypes] Fetch UserTypes');
