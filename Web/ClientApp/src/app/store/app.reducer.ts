import { ActionReducerMap } from '@ngrx/store';
import * as fromUsers from '../users/store/user.reducer';
import * as fromUserTypes from '../user-types/store/user-type.reducer';
import * as fromUserTitles from '../user-titles/store/user-title.reducer';

export interface AppState {
  userTypes: fromUserTypes.State;
  userTitles: fromUserTitles.State;
  userState: fromUsers.State;
}

export const appReducer: ActionReducerMap<AppState> = {
  userTypes: fromUserTypes.userTypeReducer,
  userTitles: fromUserTitles.userTitleReducer,
  userState: fromUsers.userReducer,
};
