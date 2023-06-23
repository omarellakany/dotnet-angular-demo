export class Stock {
  id: number;
  name: string;
  price: number;

  constructor(stock: Stock) {
    this.id = stock.id;
    this.name = stock.name;
    this.price = stock.price;
  }
}
