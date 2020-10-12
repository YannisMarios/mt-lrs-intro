import { Action, createReducer, on } from '@ngrx/store';
import { UserType } from '../user-type.model';
import * as UserTypeActions from './user-type.actions';

export interface State {
  userTypes: UserType[];
}

const initialState: State = {
  userTypes: [],
};

const _userTypeReducer = createReducer(
  initialState,
  on(UserTypeActions.setUserTypes, (state, action) => ({
    ...state,
    userTypes: action.userTypes,
  }))
);

export function userTypeReducer(state: State, action: Action) {
  return _userTypeReducer(state, action);
}
