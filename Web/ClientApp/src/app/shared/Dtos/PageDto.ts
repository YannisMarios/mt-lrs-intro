export interface PageDto<T> {
  items: T[];
  pageCount: number;
  totalCount: number;
  currentPage?: number;
}
