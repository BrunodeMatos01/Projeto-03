import { Routes } from '@angular/router';
import { RegisterSaleComponent } from './pages/register-sale/register-sale.component';

export const routes: Routes = [
    {path: '', redirectTo: 'login', pathMatch: 'full'},
    {path: ':register-sale', component: RegisterSaleComponent}
];
