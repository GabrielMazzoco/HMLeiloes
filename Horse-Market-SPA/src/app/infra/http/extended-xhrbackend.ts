import { Injectable } from '@angular/core';
import {HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse, HttpErrorResponse} from '@angular/common/http';
import { Observable } from '../../../../node_modules/rxjs';

@Injectable()
export class ExtendedXHRBackend implements HttpInterceptor {

    // constructor(public autenticacaoService: AutenticacaoService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

      // const requestUrl: Array<any> = request.url.split('/');
      // const naoRealizados = requestUrl.find(u => u === 'nao-realizados');
      // const usuarios = requestUrl.find(u => u === 'usuarios');

      // if (this.autenticacaoService.validateToken()) {

      //   const token = LocalStorageUtils.get('tokenKey');

      //   request = request.clone({
      //     setHeaders: {
      //       Authorization: `Bearer ${token}`
      //     }
      //   });

      // }

      // next.handle(request).subscribe((event: HttpEvent<any>) => {

      //   if (event instanceof HttpResponse) {
      //   }

      // }, (err: any) => {

      //   if (err instanceof HttpErrorResponse) {

      //     if (err.status === 401) {

      //     }

      //   }

      // });

      return next.handle(request);

    }

}
