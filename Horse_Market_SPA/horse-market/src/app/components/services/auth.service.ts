import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user.model';
import { map } from 'rxjs/operators';
import { BaseService } from 'src/app/infra/base-service';
import { HttpClientConnection } from 'src/app/infra/http/http-client-connection';
import { RequestStatusService } from 'src/app/infra/request-status.service';
import { HttpConnectionBuilder } from 'src/app/infra/http/http-connection-builder';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements BaseService {
  public requestEnd: boolean;
  public isShowBigLoading: boolean;
  jwtHelper: JwtHelperService = new JwtHelperService();
  decodedToken: any;
  baseUrl = 'http://localhost:5000/api/';

  constructor(
    private httpConnection: HttpClientConnection,
    public requestStatusService: RequestStatusService) { }

  public logar(user: User, handlerSucess: (value: any) => void) {
    return new HttpConnectionBuilder<any>(
      this.httpConnection,
      this.requestStatusService
    )
    .addServerDomain(`${this.baseUrl}Auth/login`)
    .addParameter(user)
    .addHandlerSuccess(handlerSucess)
    .buildPost();

  }
}
