import { Routes } from '@angular/router';
import { RegisterSaleComponent } from './pages/register-sale/register-sale.component';
import { LoginComponent } from './pages/login/login.component';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: ':register-sale', component: RegisterSaleComponent}
];
