import { Component, OnInit, Input } from '@angular/core';
import { Leilao } from 'app/models/leilao.model';

@Component({
  selector: 'app-leilao-card',
  templateUrl: './leilao-card.component.html',
  styleUrls: ['./leilao-card.component.scss']
})
export class LeilaoCardComponent implements OnInit {
  @Input() leilao: Leilao;

  constructor() { }

  ngOnInit() {
  }

}
