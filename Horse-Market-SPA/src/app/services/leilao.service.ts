import { Injectable } from '@angular/core';
import { BaseService } from 'app/infra/base-service';
import { HttpClientConnection } from 'app/infra/http/http-client-connection';
import { RequestStatusService } from 'app/infra/request-status.service';
import { HttpConnectionBuilder } from 'app/infra/http/http-connection-builder';

@Injectable({
  providedIn: 'root'
})
export class LeilaoService implements BaseService {
  public requestEnd: boolean;
  public isShowBigLoading: boolean;
  baseUrl = 'http://localhost:5000/api/';

  constructor(
    private httpConnection: HttpClientConnection,
    public requestStatusService: RequestStatusService) { }

    getLeiloes(handlerSucess: (value: any) => void, handlerError: (value: any) => void) {
      return new HttpConnectionBuilder<any>(
        this.httpConnection,
        this.requestStatusService
      )
      .addServerDomain(`${this.baseUrl}Leiloes/`)
      .addHandlerSuccess(handlerSucess)
      .addHandlerError(handlerError)
      .buildGet();
    }

    getLeilao(handlerSucess: (value: any) => void, handlerError: (value: any) => void, idLeilao: string) {
      return new HttpConnectionBuilder<any>(
        this.httpConnection,
        this.requestStatusService
      )
      .addServerDomain(`${this.baseUrl}Leiloes/${idLeilao}`)
      .addHandlerSuccess(handlerSucess)
      .addHandlerError(handlerError)
      .buildGet();
    }

}
