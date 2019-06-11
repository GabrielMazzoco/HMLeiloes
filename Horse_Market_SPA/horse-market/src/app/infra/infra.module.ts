import { AppRoutingModule } from '../app-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpClientConnection } from './http/http-client-connection';
import { NgModule } from '@angular/core';


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
