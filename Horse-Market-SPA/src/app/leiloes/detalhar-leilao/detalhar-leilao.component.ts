import { Component, OnInit } from '@angular/core';
import { Leilao } from 'app/models/leilao.model';
import { ActivatedRoute } from '@angular/router';
import { LeilaoService } from 'app/services/leilao.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-detalhar-leilao',
  templateUrl: './detalhar-leilao.component.html',
  styleUrls: ['./detalhar-leilao.component.scss']
})
export class DetalharLeilaoComponent implements OnInit {
  leilao: Leilao = new Leilao();

  constructor(private route: ActivatedRoute, private leilaoService: LeilaoService, private toastr: ToastrService) { }

  ngOnInit() {
    const idLeilao = this.route.snapshot.paramMap.get('id');

    this.leilaoService.getLeilao(value => {
      this.leilao = value;
    }, error => {
      this.toastr.error(error)
    }, idLeilao);
  }
}
