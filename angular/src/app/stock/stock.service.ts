import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Stock } from './stock';
import config from 'src/env/config';
import { HttpClient } from '@angular/common/http';
import * as signalR from '@microsoft/signalr';

@Injectable()
export class StockService {
  private stocksSource = new BehaviorSubject<Stock[]>([]);
  stocks$ = this.stocksSource.asObservable();

  constructor(private http: HttpClient) {
    this.http.get<Stock[]>(`${config.baseUrl}/stocks`).subscribe((stocks$) => {
      this.stocksSource.next(stocks$);
      console.log(this.stocksSource);
    });

    const connection = new signalR.HubConnectionBuilder()
      .withUrl(`${config.baseUrl}/subscribe`, {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets,
      })
      .build();

    connection
      .start()
      .catch((err) => console.error(err.toString()))
      .then(() => {
        connection.on('UpdateStockPrice', (stock: Stock) => {
          const index = this.stocksSource.value.findIndex(
            (s) => s.id === stock.id
          );
          this.stocksSource.value[index].price = stock.price;
        });
      });
  }
}
