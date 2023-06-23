import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order } from './order';
import config from 'src/env/config';
import { Stock } from '../stock/stock';
import { StockService } from '../stock/stock.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
})
export class OrderComponent implements OnInit {
  stocks: Stock[] = [];
  orders: Order[] = [];

  @Input() selectedStock: Stock | undefined;
  @Input() quantity: number = 1;
  @Input() name: string = '';

  constructor(private stockService: StockService, private http: HttpClient) {}

  async ngOnInit() {
    this.stockService.stocks$.subscribe((stocks) => {
      this.stocks = stocks;
    });

    this.http.get<Order[]>(`${config.baseUrl}/orders`).subscribe((orders) => {
      this.orders = orders;
    });
  }

  selectStock(stock: Stock) {
    this.selectedStock = stock;
  }

  submitOrder() {
    if (this.selectedStock) {
      const upcomingOrder: Order = {
        id: 0,
        stockId: this.selectedStock.id,
        quantity: this.quantity,
        userName: this.name,
        price: this.selectedStock.price,
        stockName: this.selectedStock.name,
      };

      this.http
        .post<Order>(`${config.baseUrl}/orders`, upcomingOrder)
        .subscribe((order) => {
          this.orders.push(order);
        });
    }
  }
}
