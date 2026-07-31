import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export interface Product {
  productId: number;
  type: string;
  brand: string;
  productName: string;
  price: number;
}

@Injectable({ providedIn: 'root' })
export class ProductService {
  private baseUrl = `${environment.apiBaseUrl}/Products`;
  
  constructor(private http: HttpClient) {}

  // ✅ Fetch all products
  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseUrl}/GetAllProducts`);
  }

  // ✅ Search products by name
  searchProducts(name: string): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseUrl}/SearchProducts?name=${name}`);
  }
}
