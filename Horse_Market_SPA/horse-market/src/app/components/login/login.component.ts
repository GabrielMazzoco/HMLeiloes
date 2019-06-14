import { Component, OnInit } from '@angular/core';
import { User } from '../models/user.model';
import { AuthService } from '../services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { LocalStorageUtils } from 'src/app/shared/utils/localstorage.utils';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public model: User = new User();
  public isLogado = false;

  constructor(
    public authService: AuthService,
    private toastrService: ToastrService,
    private router: Router) { }

  ngOnInit() {
  }

  login() {
    this.authService.logar(this.model, response => {
      LocalStorageUtils.push('token', response.token);
      LocalStorageUtils.push('username', response.username);
      this.toastrService.success('Logado com sucesso!');
      this.isLogado = true;
    });
  }
}
