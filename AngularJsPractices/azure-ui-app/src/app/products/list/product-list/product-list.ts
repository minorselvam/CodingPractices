import { Component, Input } from '@angular/core';
import { Product } from '../../services/product-service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.html',
  styleUrls: ['./product-list.css']
})
export class ProductListComponent {
  @Input() products: Product[] = [];
}

