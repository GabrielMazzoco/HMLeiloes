import { Injectable } from '@angular/core';
import { HttpClientConnection } from 'app/infra/http/http-client-connection';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BaseService } from 'app/infra/base-service';
import { RequestStatusService } from 'app/infra/request-status.service';
import { User } from 'app/models/user.model';
import { HttpConnectionBuilder } from 'app/infra/http/http-connection-builder';

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
