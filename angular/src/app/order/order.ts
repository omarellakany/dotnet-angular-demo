export class Order {
  id: number;
  userName: string;
  price: number;
  quantity: number;
  stockId: number;
  stockName: string;

  constructor(order: Order) {
    this.id = order.id;
    this.userName = order.userName;
    this.price = order.price;
    this.quantity = order.quantity;
    this.stockId = order.stockId;
    this.stockName = order.stockName;
  }
}
