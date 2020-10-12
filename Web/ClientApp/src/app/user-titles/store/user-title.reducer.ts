import { Action, createReducer, on } from '@ngrx/store';
import { UserTitle } from '../user-title.model';
import * as UserTitleActions from './user-title.actions';

export interface State {
  userTitles: UserTitle[];
}

const initialState: State = {
  userTitles: [],
};

const _userTitleReducer = createReducer(
  initialState,
  on(UserTitleActions.setUserTitles, (state, action) => ({
    ...state,
    userTitles: action.userTitles,
  }))
);

export function userTitleReducer(state: State, action: Action) {
  return _userTitleReducer(state, action);
}
