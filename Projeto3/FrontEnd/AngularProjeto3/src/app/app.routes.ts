import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { ReportComponent } from './pages/report/report.component';
import { RegisterSaleComponent } from './pages/register-sale/register-sale.component';
import { LoginVendedoresComponent } from './pages/login-vendedores/login-vendedores.component';

export const routes: Routes = [
    // {path: '', redirectTo: '/login', pathMatch: 'full'},
    {path: 'login', component: LoginComponent},
    {path: 'login-seller', component: LoginVendedoresComponent},
    {path: '', component: ReportComponent},
    {path: 'register', component: RegisterSaleComponent}
];

