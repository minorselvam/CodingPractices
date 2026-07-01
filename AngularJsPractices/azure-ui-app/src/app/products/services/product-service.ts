import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Product {
  productId: number;
  type: string;
  brand: string;
  productName: string;
  price: number;
}

@Injectable({ providedIn: 'root' })
export class ProductService {
  private apiUrl = 'https://localhost:44388/api/Product'; // adjust to your backend URL

  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl);
  }
}
