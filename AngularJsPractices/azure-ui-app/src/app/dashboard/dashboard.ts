import { Component } from '@angular/core';
import { ProductService, Product } from '../products/services/product-service';
import { CommonModule } from '@angular/common';
import { ProductFilterComponent } from '../products/filter/product-filter/product-filter';
import { ProductListComponent } from '../products/list/product-list/product-list';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, ProductFilterComponent, ProductListComponent],
  templateUrl: 'dashboard.html'
})
export class DashboardComponent {
  allProducts: Product[] = [];
  filteredProducts: Product[] = [];

  constructor(private productService: ProductService) {}

  ngOnInit() {
    this.productService.getProducts().subscribe(data => {
      this.allProducts = data;
      this.filteredProducts = data; // default show all
    });
  }

  onFilterChange(filter: { type: string; brand: string }) {
    this.filteredProducts = this.allProducts.filter(p =>
      (!filter.type || p.type === filter.type) &&
      (!filter.brand || p.brand === filter.brand)
    );
  }
}
