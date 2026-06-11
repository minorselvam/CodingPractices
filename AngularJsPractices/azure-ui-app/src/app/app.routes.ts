import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import { Order } from './order/order';
import {Payment} from './payment/payment';
import {Shipping} from './shipping/shipping';
import {OrderList} from './order-list/order-list';

export const routes: Routes = [
    {path:'Order', component:Order},
    {path:'Payment', component:Payment},
    {path:'Shipping', component:Shipping},
    {path:'OrderList', component:OrderList},
    // Default route → Order
  { path: '', redirectTo: '/Order', pathMatch: 'full' }
];
