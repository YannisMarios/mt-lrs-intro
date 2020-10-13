import { UserTitle } from '../user-titles/user-title.model';
import { UserType } from '../user-types/user-type.model';

export interface User {
  id?: number;
  name?: string;
  surname?: string;
  birthDate?: Date;
  userType?: UserType;
  userTypeId?: number;
  userTitle?: UserTitle;
  userTitleId?: number;
  emailAddress?: string;
  isActive?: boolean;
}

export interface SearchUsersParamsDto {
  searchString: string;
  pageIndex: number;
  pageSize: number;
}
