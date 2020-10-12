import { UserTitle } from '../user-titles/user-title.model';
import { UserType } from '../user-types/user-type.model';

export class User {
  public id?: number;
  public name?: string;
  public surname?: string;
  public birthDate?: Date;
  public userType?: UserType;
  public userTypeId?: number;
  public userTitle?: UserTitle;
  public userTitleId?: number;
  public emailAddress?: string;
  public isActive?: boolean;

  constructor(
    name?: string,
    surname?: string,
    birthDate?: Date,
    userType?: UserType,
    userTypeId?: number,
    userTitle?: UserTitle,
    userTitleId?: number,
    emailAddress?: string,
    isActive?: boolean
  ) {
    this.name = name;
    this.surname = surname;
    this.birthDate = birthDate;
    this.userType = userType;
    this.userTypeId = userTypeId;
    this.userTitle = userTitle;
    this.userTitleId = userTitleId;
    this.emailAddress = emailAddress;
    this.isActive = isActive;
  }
}

export class SearchUsersParamsDto {
  searchString: string;
  pageIndex: number;
  pageSize: number;
}
