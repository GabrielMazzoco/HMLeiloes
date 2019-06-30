import { RequestStatusService } from './request-status.service';

export abstract class BaseService {

    public requestEnd: boolean;
    public isShowBigLoading: boolean;

    constructor(public requestStatusService: RequestStatusService) {
        this.requestStatusService.isRequestEnd.subscribe(isEnd => {
            this.requestEnd = isEnd;
        });
        this.requestStatusService.isShowBigLoading.subscribe(show => {
            this.isShowBigLoading = show;
        });
    }
}
