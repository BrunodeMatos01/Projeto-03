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
  showNavbar = true;
  menuOpen = false;

  constructor(private router: Router) {
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe(event => {
      const nav = event as NavigationEnd; // Type assertion
      const hiddenRoutes = ['/login', '/create-account'];
      this.showNavbar = !hiddenRoutes.includes(nav.urlAfterRedirects);
    });
  }
  

  toggleMenu() {
    this.menuOpen = !this.menuOpen;
  }

  onLogout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}
