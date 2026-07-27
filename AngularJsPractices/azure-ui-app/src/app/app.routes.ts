import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { Order } from './order/order';
import { Payment } from './payment/payment';
import { Shipping } from './shipping/shipping';
import { CustomerComponent } from './customer/customer.component';

export const routes: Routes = [
  { path: 'Dashboard', component: DashboardComponent },
  { path: 'Order', component: Order },
  { path: 'Payment', component: Payment },
  { path: 'Shipping', component: Shipping },
  { path: 'Customer', component: CustomerComponent },

  // Default route → Dashboard
  { path: '', redirectTo: '/Dashboard', pathMatch: 'full' }
];
