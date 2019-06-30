import { HttpClientConnection } from './http-client-connection';
import { Subscription, Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { HttpClient } from '../../../../node_modules/@angular/common/http';
import { RequestStatusService } from '../request-status.service';
declare var $: any;

export class HttpConnectionBuilder<T> {
    url = '';
    endPoint = '';
    isBigLoading = true;

    key: string = null;
    parameters: any = [];
    parametersPagination: any = [];
    file: any = null;
    showMsgError = true;
    showMsgSucess = false;
    handlerSuccess: (value: T) => void;
    handlerError: (value: any) => void;
    handlerComplete: () => void;
    handlerMap: (value: Response) => T;
    httpClient: HttpClient;
    pParams;

    header: Headers;

    constructor(protected httpClientConnection: HttpClientConnection,
                public requestStatusService?: RequestStatusService) {
        this.httpClient = this.httpClientConnection.http;
        this.updateLoading(true);
    }

    addServerDomain(urlServerDomain: string): HttpConnectionBuilder<T> {
        this.url += urlServerDomain;

        return this;
    }

    addEndPoint(endPoint: string): HttpConnectionBuilder<T> {
        this.endPoint += endPoint;

        return this;
    }

    addPage(page: number): HttpConnectionBuilder<T> {
        this.addPagination(10, page);

        return this;
    }

    addPagination(size: number, page: number): HttpConnectionBuilder<T> {
        this.parametersPagination = { 'size': size, 'page': page };

        return this;
    }

    addParameter(parameters: any): HttpConnectionBuilder<T> {
        this.parameters = parameters;

        return this;
    }

    addFileParameter(file: any): HttpConnectionBuilder<T> {
        this.file = file;

        return this;
    }

    addHandlerError(handlerError: (value: any) => void): HttpConnectionBuilder<T> {
        this.handlerError = handlerError;

        return this;
    }

    addHandlerSuccess(handlerSuccess: (value: T) => void): HttpConnectionBuilder<T> {
        this.handlerSuccess = handlerSuccess;

        return this;
    }

    addHandlerMap(handlerMap: (value: Response) => T): HttpConnectionBuilder<T> {
        this.handlerMap = handlerMap;

        return this;
    }

    addHandlerComplete(handlerComplete: () => void): HttpConnectionBuilder<T> {
        this.handlerComplete = handlerComplete;

        return this;
    }

    generateFormData(keyForm: string, keyFile?: string): HttpConnectionBuilder<T> {
        const formData: FormData = new FormData();
        formData.append(keyForm, JSON.stringify(this.parameters));

        if (keyFile != null) {
            formData.append(keyFile, this.file, this.file.name);
        }

        this.parameters = formData;

        return this;
    }

    generateParametersJson(): HttpConnectionBuilder<T> {
        this.parameters = JSON.stringify(this.parameters);
        return this;
    }

    hideToastErro(): HttpConnectionBuilder<T> {
        this.showMsgError = false;

        return this;
    }

    showToastSucess(): HttpConnectionBuilder<T> {
        this.showMsgSucess = true;

        return this;
    }

    buildPost(): Subscription {
        this.addLoading();
        return this.httpClient.post(this.createURL(), this.parameters)
            .subscribe(
                res => {
                    const v = this.doParseJson(res);
                    this.doSuccess(v);
                },
                err => this.doError(err),
                () => { this.doComplete(); }
            );
    }

    buildPut(): Subscription {
        this.addLoading();
        return this.httpClient.put(this.createURL(), this.parameters)
            .subscribe(
                res => {
                    const v = this.doParseJson(res);
                    this.doSuccess(v);
                },
                err => this.doError(err),
                () => { this.doComplete(); }
            );
    }

    buildGet(chave?: string): Subscription {

        if (chave) {
            this.parameters = { [chave]: this.parameters };
        }

        const options = { params: this.parameters };

        this.addLoading();
        return this.httpClient.get(this.createURL(), options)
            .subscribe(
                res => {
                    const v = this.doParseJson(res);
                    this.doSuccess(v);
                },
                err => this.doError(err),
                () => { this.doComplete(); }
            );

    }

    buildDelete(chave?: string): Subscription {
        if (chave) {
            this.parameters = { [chave]: this.parameters };
        }

        const options = { params: this.parameters };

        this.addLoading();
        return this.httpClient.delete(this.createURL(), options)
            .subscribe(
                res => {
                    const v = this.doParseJson(res);
                    this.doSuccess(v);
                },
                err => this.doError(err),
                () => { this.doComplete(); }
            );
    }

    private doParseJson(response: any): T {
        const obj = <Response>response;
        try {
            return <T>(obj || {});
        } catch (e) {
            return null;
        }
    }

    private doSuccess(response: any) {
        this.removeLoading();
        if (this.handlerSuccess) {
            this.handlerSuccess(<T>response);
        }
    }

    private doComplete() {
        this.removeLoading();
        if (this.handlerComplete) {
            this.handlerComplete();
        }
    }

    private doError(err: any) {
        this.removeLoading();
        if (this.handlerError) {
            this.handlerError(err);
        }

        throw err;
    }

    private removeLoading(): void {
        if (this.requestStatusService) {
            this.requestStatusService.updateRequestEndStatus(true);
            this.requestStatusService.updateForceBigLoading(false);
        }
    }

    private addLoading(): void {
        if (this.requestStatusService) {
            this.requestStatusService.updateRequestEndStatus(false);
        }
    }

    showBigLoading(show?: boolean): HttpConnectionBuilder<T> {
        if (show != null) {
            this.isBigLoading = show;
            this.updateLoading(show);
        } else {
            this.isBigLoading = true;
            this.updateLoading(true);
        }
        return this;
    }

    private updateLoading(show: boolean): void {
        if (this.requestStatusService) {
            this.requestStatusService.updateShowBigLoading(show);
        }
    }

    private createQueryString(): string {
        let queryString = '';
        let colocarEComercial = false;

        for (const key in this.parameters) {
            if (this.parameters.hasOwnProperty(key)) {
                if (this.parameters[key]) {
                    if (colocarEComercial) {
                        queryString += '&';
                    }
                    queryString += key + '=' + this.parameters[key];

                    if (!colocarEComercial) {
                        colocarEComercial = true;
                    }
                }
            }
        }

        for (const key in this.parametersPagination) {
            if (this.parametersPagination.hasOwnProperty(key)) {
                if (colocarEComercial) {
                    queryString += '&';
                }

                queryString += key + '=' + this.parameters[key];

                if (!colocarEComercial) {
                    colocarEComercial = true;
                }
            }
        }

        if (queryString !== '') {
            return '?' + queryString;
        }

        return '';
    }

    private createURL(): string {
        if (this.url === '') {
            this.addApplicationServerDomain();
        }

        return this.url + this.endPoint;
    }

    private addApplicationServerDomain() {
        this.url += environment.production;
    }

    buildGetObservable(): Observable<any> {
        this.addLoading();
        return this.httpClient.get(this.createURL() + this.createQueryString())
            .pipe(map(response => { this.doSuccess(response); }));
    }
}
