import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StockComponent } from './stock/stock.component';
import { OrderComponent } from './order/order.component';

const routes: Routes = [
  { path: '', component: StockComponent },
  { path: 'stocks', redirectTo: '' },
  { path: 'orders', component: OrderComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
