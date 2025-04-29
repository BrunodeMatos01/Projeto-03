import { Routes } from '@angular/router';
import { LoginComponent }         from './pages/login/login.component';
import { CreateAccountComponent } from './pages/create-account/create-account.component';
import { RegisterSaleComponent } from './pages/register-sale/register-sale.component';
import { ReportComponent } from './pages/report/report.component';

export const routes: Routes = [
  { path: '',               redirectTo: 'login',         pathMatch: 'full' },    
  { path: 'login',          component: LoginComponent    },   
  { path: 'create-account', component: CreateAccountComponent },   
  { path: 'register-sale',  component: RegisterSaleComponent },
  { path: 'report',  component: ReportComponent },
  { path: '**',             redirectTo: 'login'          }    
];
