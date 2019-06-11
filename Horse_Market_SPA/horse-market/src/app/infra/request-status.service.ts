import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable()
export class RequestStatusService {

    public isRequestEnd: Subject<boolean> = new Subject();
    public isShowBigLoading: Subject<boolean> = new Subject();
    public forceLoading: Subject<boolean> = new Subject();

    public updateRequestEndStatus(isRequestEnd: boolean): void {
        this.isRequestEnd.next(isRequestEnd);
    }

    public updateShowBigLoading(showLoading: boolean): void {
        this.isShowBigLoading.next(showLoading);
    }

    public updateForceBigLoading(showLoading: boolean): void {
        this.forceLoading.next(showLoading);
    }

}
