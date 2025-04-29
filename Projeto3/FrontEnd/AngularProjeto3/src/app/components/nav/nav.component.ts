import { Component } from '@angular/core';
import { Router, NavigationEnd, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [RouterModule, CommonModule, RouterOutlet],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  route = new Router;
  showNavbar = true;

  menuOpen = false;
 
  constructor(private router: Router) {}
 
  toggleMenu() {

    this.menuOpen = !this.menuOpen;

  }
 
  onLogout() {

    // Limpa dados de autenticação (ajuste conforme seu projeto)

    localStorage.clear();
 
    // Redireciona para a tela de login

    this.router.navigate(['/login']);

  }
 
}
