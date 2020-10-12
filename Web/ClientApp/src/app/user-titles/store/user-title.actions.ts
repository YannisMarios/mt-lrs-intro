import { createAction, props } from '@ngrx/store';
import { UserTitle } from '../user-title.model';

export const setUserTitles = createAction(
  '[UserTitles] Set UserTitles',
  props<{
    userTitles: UserTitle[];
  }>()
);

export const fetchUserTitles = createAction('[UserTitles] Fetch UserTitles');
