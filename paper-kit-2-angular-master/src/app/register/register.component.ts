import { Component, OnInit } from '@angular/core';
import { User } from 'app/models/user.model';
import { AuthService } from 'app/services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public model: User = new User();
  public ngbDate: any;

  constructor(
    public authService: AuthService,
    private toastrService: ToastrService,
    private router: Router) { }

  ngOnInit() {
  }

  public register() {
    this.model.dateOfBirth = new Date(this.ngbDate.year, this.ngbDate.month - 1, this.ngbDate.day);
    this.authService.register(this.model, () => {
      this.toastrService.success('Cadastrado com Sucesso!');
      this.router.navigateByUrl('/signin');
    }, error => {
      this.toastrService.error(error.message);
    });
  }
}
