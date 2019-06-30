import { Component, OnInit } from '@angular/core';
import { Leilao } from 'app/models/leilao.model';
import { LeilaoService } from 'app/services/leilao.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})

export class HomeComponent implements OnInit {
    model = {
        left: true,
        middle: false,
        right: false
    };
    leiloes: Leilao[] = [];

    focus;
    focus1;
    constructor(private leilaoService: LeilaoService, private toastrService: ToastrService) { }

    ngOnInit() {
        this.getLeiloes();
    }

    private getLeiloes() {
        this.leilaoService.getLeiloes(response => {
            this.leiloes = response;
        }, error => {
            this.toastrService.error(error.message);
        });
    }
}
