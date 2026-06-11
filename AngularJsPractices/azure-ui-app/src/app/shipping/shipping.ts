import { Component } from '@angular/core';
import {Router } from '@angular/router';


@Component({
  selector: 'app-shipping',
  imports: [],
  templateUrl: './shipping.html',
  styleUrl: './shipping.css',
})
export class Shipping {
 constructor(private router:Router) {  }

 goToOrder() {
    this.router.navigate(['Order']);
  }
}
