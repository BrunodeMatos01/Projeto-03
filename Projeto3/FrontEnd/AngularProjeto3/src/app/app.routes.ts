import { Routes } from '@angular/router';
// import { RegisterSaleComponent } from './pages/register-sale/register-sale.component';
import { LoginComponent } from './pages/login/login.component';
import { ReportComponent } from './pages/report/report.component';
import { LoginVendedoresComponent } from './pages/login-vendedores/login-vendedores.component';

export const routes: Routes = [
    // {path: '', redirectTo: '/login', pathMatch: 'full'},
    {path: 'login', component: LoginComponent},
    {path: 'login-seller', component: LoginVendedoresComponent},
    {path: '', component: ReportComponent},
    // {path: 'register-sale', component: RegisterSaleComponent}
];