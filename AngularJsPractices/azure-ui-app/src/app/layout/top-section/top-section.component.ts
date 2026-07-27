import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ProductService } from '../../products/services/product.service';

@Component({
  selector: 'app-top-section',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './top-section.component.html',
  styleUrls: ['./top-section.component.css']
})
export class TopSectionComponent {
  query = '';

  constructor(private productService: ProductService, private router: Router) {}

  search() {
    // Extend ProductService with search API call if needed
    this.productService.getProducts().subscribe();
  }

  goToCustomer() {
    this.router.navigate(['/Customer']);
  }
}
