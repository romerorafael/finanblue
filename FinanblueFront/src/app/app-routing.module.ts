import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './component/home/home.component';
import { CompanyComponent } from './component/company/company.component';
import { ProductComponent } from './component/product/product.component';
import { PurchaseComponent } from './component/purchase/purchase.component';
import { NotFoundComponent } from './component/not-found/not-found.component';

const routes: Routes = [
  {path:"", component: HomeComponent},
  {path:"company", component: CompanyComponent},
  {path:"product", component: ProductComponent},
  {path:"purchase", component: PurchaseComponent},
  {path:"*", component: NotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
