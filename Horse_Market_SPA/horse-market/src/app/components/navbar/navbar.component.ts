import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { User } from '../models/user.model';
import { LocalStorageUtils } from 'src/app/shared/utils/localstorage.utils';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  public model: User = new User();

  constructor(
    public authService: AuthService,
    private toastrService: ToastrService,
    private router: Router) { }

  ngOnInit() {
  }

  login() {
    this.authService.logar(this.model, response => {
      console.log(response);
    });
  }
}
