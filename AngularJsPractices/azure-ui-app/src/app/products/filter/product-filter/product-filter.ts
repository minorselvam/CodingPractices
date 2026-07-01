import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ProductService, Product } from '../../services/product-service';
import { FormsModule } from '@angular/forms';   // ✅ import FormsModule
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-filter',
  standalone: true,
  imports: [CommonModule, FormsModule],   // ✅ add FormsModule here
  templateUrl: './product-filter.html'
})
export class ProductFilterComponent implements OnInit {
  products: Product[] = [];
  productTypes: string[] = [];
  brands: string[] = [];

  selectedType = '';
  selectedBrand = '';

  @Output() filterChanged = new EventEmitter<{ type: string; brand: string }>();

  constructor(private productService: ProductService) {}

  ngOnInit() {
    this.productService.getProducts().subscribe(data => {
      this.products = data;
      this.productTypes = [...new Set(data.map(p => p.type))];
      this.brands = [...new Set(data.map(p => p.brand))];
    });
  }

  onSelectionChange() {
    this.filterChanged.emit({ type: this.selectedType, brand: this.selectedBrand });
  }
}
