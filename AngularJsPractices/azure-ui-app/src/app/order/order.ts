import { Component } from '@angular/core';
import {Router } from '@angular/router';

@Component({
  selector: 'app-order',
  imports: [],
  templateUrl: './order.html',
  styleUrl: './order.css',
})
export class Order {
  constructor(private router:Router) {

  }

  goToPayment() {
    this.router.navigate(['Payment']);
  }
}
