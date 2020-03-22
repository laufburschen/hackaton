export interface Order {
  id?: number;
  orderItems: OrderItem[]
}

export interface OrderItem {
  id?: number;
  product: string;
  items: number;
  maxPricePerItem: number;
  comment: string;
}

