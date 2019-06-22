import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';

import { HomeComponent } from './home.component';

import { ComponentsModule } from '../components/components.module';
import { LeilaoCardComponent } from 'app/leiloes/leilao-card/leilao-card.component';
import { LeilaoService } from 'app/services/leilao.service';

@NgModule({
    imports: [
        CommonModule,
        BrowserModule,
        FormsModule,
        RouterModule,
        ComponentsModule
    ],
    declarations: [ HomeComponent, LeilaoCardComponent ],
    exports:[ HomeComponent ],
    providers: [LeilaoService]
})
export class HomeModule { }
