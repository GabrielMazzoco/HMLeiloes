import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpClientConnection {

    constructor(public http: HttpClient) { }
}
