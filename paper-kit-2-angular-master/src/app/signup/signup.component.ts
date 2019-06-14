import { Component, OnInit } from '@angular/core';
import { User } from 'app/models/user.model';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { LocalStorageUtils } from 'app/shared/utils/localstorage.utils';
import { AuthService } from 'app/services/auth.service';

@Component({
    selector: 'app-signup',
    templateUrl: './signup.component.html',
    styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
    test : Date = new Date();
    focus;
    focus1;
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
