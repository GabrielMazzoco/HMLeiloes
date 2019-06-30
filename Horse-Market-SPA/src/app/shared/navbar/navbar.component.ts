import { Component, OnInit, ElementRef } from '@angular/core';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
    private toggleButton: any;
    private sidebarVisible: boolean;
    private jwtHelper: JwtHelperService = new JwtHelperService();

    constructor(public location: Location, private element: ElementRef) {
        this.sidebarVisible = false;
    }

    ngOnInit() {
        const navbar: HTMLElement = this.element.nativeElement;
        this.toggleButton = navbar.getElementsByClassName('navbar-toggler')[0];
    }
    sidebarOpen() {
        const toggleButton = this.toggleButton;
        const html = document.getElementsByTagName('html')[0];
        // console.log(html);
        // console.log(toggleButton, 'toggle');

        setTimeout(function(){
            toggleButton.classList.add('toggled');
        }, 500);
        html.classList.add('nav-open');

        this.sidebarVisible = true;
    };
    sidebarClose() {
        const html = document.getElementsByTagName('html')[0];
        // console.log(html);
        this.toggleButton.classList.remove('toggled');
        this.sidebarVisible = false;
        html.classList.remove('nav-open');
    };
    sidebarToggle() {
        // const toggleButton = this.toggleButton;
        // const body = document.getElementsByTagName('body')[0];
        if (this.sidebarVisible === false) {
            this.sidebarOpen();
        } else {
            this.sidebarClose();
        }
    };
    isHome() {
        const titlee = this.location.prepareExternalUrl(this.location.path());

        if ( titlee === '/home' ) {
            return true;
        } else {
            return false;
        }
    }
    isDocumentation() {
        const titlee = this.location.prepareExternalUrl(this.location.path());
        if ( titlee === '/documentation' ) {
            return true;
        } else {
            return false;
        }
    }
    isSignUp() {
        const titlee = this.location.prepareExternalUrl(this.location.path());
        if ( titlee === '/signin' ) {
            return true;
        } else {
            return false;
        }
    }
    isRegister() {
        const titlee = this.location.prepareExternalUrl(this.location.path());
        if ( titlee === '/register' ) {
            return true;
        } else {
            return false;
        }
    }

    isLoggedIn() {
        const token = localStorage.getItem('token');
        return !this.jwtHelper.isTokenExpired(token);
    }

    sair() {
        localStorage.removeItem('token');
        localStorage.removeItem('username');
    }
}
