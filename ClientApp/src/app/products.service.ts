import { Injectable } from '@angular/core';
import { Product } from './product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  public products: Product[] = [];
  constructor() { 
    this.products.push(new Product("Hallo", 2, 3.0));
    this.products.push(new Product("Welt", 2, 3.0));
  }
}
