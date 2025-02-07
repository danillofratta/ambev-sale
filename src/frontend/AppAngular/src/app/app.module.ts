import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SaleApi } from '../domain/api/SaleApi';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCardModule } from '@angular/material/card';
import { ProductComponent } from './pages/dashboard/product/product.component';
import { ProductApi } from '../domain/api/ProductApi';
import { ProductAutoCompleteComponent } from './components/product-auto-complete/product-auto-complete.component';
import { SignalRSaleService } from '../domain/signalr/SignalRSaleService';
import { ListSaleComponent } from './pages/dashboard/sale/list-sale/list-sale.component';
import { CreateSaleComponent } from './pages/dashboard/sale/create-sale/create-sale.component';
import { ModifySaleComponent } from './pages/dashboard/sale/modify-sale/modify-sale.component';

@NgModule({
  declarations: [
    AppComponent,

    DashboardComponent,

    LoadingSpinnerComponent,
    
    ProductComponent,
    ProductAutoCompleteComponent,

    CreateSaleComponent,
    ModifySaleComponent,
    ListSaleComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,

    HttpClientModule,

    MatIconModule,
    MatButtonModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatTableModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    BrowserAnimationsModule,
    MatCardModule
  ],
  providers: [SaleApi, provideAnimationsAsync(), SignalRSaleService, ProductApi],
  bootstrap: [AppComponent]
})
export class AppModule {
}
