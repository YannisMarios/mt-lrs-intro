import { DataSource } from '@angular/cdk/table';
import { Observable, merge, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';

export interface ISearchAction {
  searchString: string;
  pageIndex: number;
  pageSize: number;
}

export class DataTableSource<T> extends DataSource<T> {
  private _dataStream = new BehaviorSubject<T[]>([]);

  public set data(v: T[]) {
    this._dataStream.next(v);
  }

  public get data(): T[] {
    return this._dataStream.value;
  }

  connect(): Observable<T[]> {
    const dataMutations = [this._dataStream];

    return merge(...dataMutations).pipe(map(() => this._dataStream.getValue()));
  }

  disconnect() {}

  constructor() {
    super();
  }
}
