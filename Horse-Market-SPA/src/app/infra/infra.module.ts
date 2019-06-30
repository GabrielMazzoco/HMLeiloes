import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpClientConnection } from './http/http-client-connection';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from 'app/app.routing';


@NgModule({
    imports: [
        AppRoutingModule,
        HttpClientModule
    ],
    providers: [
        HttpClientConnection
    ]
  })
  export class InfraModule {}
