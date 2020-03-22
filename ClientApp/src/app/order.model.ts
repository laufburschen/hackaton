export interface Order {
  id?: string;
  orderItems: OrderItem[];
}

export interface OrderItem {
  id?: string;
  product: string;
  items: number;
  maxPricePerItem: number;
  comment: string;
}

