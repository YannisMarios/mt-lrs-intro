import { Action, createReducer, on } from '@ngrx/store';
import { PageDto } from 'src/app/shared/Dtos/PageDto';
import { userTypeReducer } from 'src/app/user-types/store/user-type.reducer';
import { User } from '../user.model';
import * as UserActions from './user.actions';

export interface State {
  users: PageDto<User>;
  user: User;
}

const initialState: State = {
  users: {
    items: [],
    pageCount: 0,
    totalCount: 0,
    currentPage: 0,
  },
  user: null,
};

const _userReducer = createReducer(
  initialState,

  on(UserActions.setUsers, (state, action) => ({
    ...state,
    users: action.users,
  })),
  on(UserActions.setUser, (state, action) => {
   const items = [...state.users.items]
   const index = items.findIndex(x => x.id === action.user.id)
   if(index !== -1) {
    items[index] = action.user
   }

   return {
    ...state,
    users: {
      ...state.users,
      items: [...state.users.items, ...items]
    },
    user: action.user,
   }
  })
);

export function userReducer(state: State, action: Action) {
  return _userReducer(state, action);
}
