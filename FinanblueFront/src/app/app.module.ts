import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule }   from '@angular/forms';

import { AppComponent } from './app.component';
import { FooterComponent } from './component/footer/footer.component';
import { HeaderComponent } from './component/header/header.component';
import { CompanyComponent } from './component/company/company.component';
import { ProductComponent } from './component/product/product.component';
import { PurchaseComponent } from './component/purchase/purchase.component';
import { HomeComponent } from './component/home/home.component';
import { NotFoundComponent } from './component/not-found/not-found.component';
import { CompanycardComponent } from './component/company/companycard/companycard.component';
import { CompanyregisterComponent } from './component/company/companyregister/companyregister.component';
import { CommonModule } from '@angular/common';
import { ProductcardComponent } from './component/product/productcard/productcard.component';
import { ProductregisterComponent } from './component/product/productregister/productregister.component';
import { PurchasecardComponent } from './component/purchase/purchasecard/purchasecard.component';
import { PurchaseregisterComponent } from './component/purchase/purchaseregister/purchaseregister.component';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    CompanyComponent,
    ProductComponent,
    PurchaseComponent,
    HomeComponent,
    NotFoundComponent,
    CompanycardComponent,
    CompanyregisterComponent,
    ProductcardComponent,
    ProductregisterComponent,
    PurchasecardComponent,
    PurchaseregisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
