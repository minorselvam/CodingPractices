import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductService } from '../products/services/product.service';   // ✅ only the service
import { Product } from '../products/services/product.service';          // ✅ interface separately
import { ProductFilterComponent } from '../products/filter/product-filter/product-filter.component';
import { ProductListComponent } from '../products/list/product-list/product-list.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, ProductFilterComponent, ProductListComponent],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  allProducts: Product[] = [];
  filteredProducts: Product[] = [];

  constructor(private productService: ProductService) {}

  ngOnInit() {
    this.productService.getProducts().subscribe(data => {
      this.allProducts = data;
      this.filteredProducts = data;
    });
  }

  onFilterChange(filter: { type: string; brand: string }) {
    this.filteredProducts = this.allProducts.filter(p =>
      (!filter.type || p.type === filter.type) &&
      (!filter.brand || p.brand === filter.brand)
    );
  }
}
