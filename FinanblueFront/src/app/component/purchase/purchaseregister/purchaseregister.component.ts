import { Component, EventEmitter, Output, OnInit } from '@angular/core';
import { Company } from 'src/app/entities/company/company';
import { Product } from 'src/app/entities/product/product';
import { PurchaseBody } from 'src/app/entities/purchase/purchase';
import { ProductSale, Purchase } from 'src/app/entities/purchase/purchase';
import { CompanyService } from 'src/app/services/company/company.service';
import { ProductService } from 'src/app/services/product/product.service';
import { PurchaseService } from 'src/app/services/purchase/purchase.service';

@Component({
  selector: 'Purchaseregister',
  templateUrl: './purchaseregister.component.html',
  styleUrls: ['./purchaseregister.component.css']
})
export class PurchaseregisterComponent implements OnInit{

  constructor(private purchaseService:PurchaseService, 
    private productService: ProductService, 
    private companyService : CompanyService)
  {}

  public purchase : Purchase = {id:0, companyId: 0, total:0}

  public products : Product[] = new Array();
  public companies: Company[] = new Array();

  public productsSale: ProductSale[] = new Array();
  public productId: number = 0;
  public quantity: number = 0;


  @Output() closeModal = new EventEmitter();

  ngOnInit(): void {
    this.productService.getAll().subscribe( (data:any) => {
      this.products = data;
    })

    this.companyService.getAll().subscribe ( (data:any) =>{
      this.companies = data;
    })
  }

  addProductSale(){
    let product = this.products.filter( x => x.id == this.productId)[0];
    let productSale = {"product": product, "quantity": this.quantity }
    this.productsSale.push(productSale);
    this.purchase.total += product.price * this.quantity;
    this.productId = 0;
    this.quantity = 0;
  }

  removeProductSale(productSale: ProductSale){
    debugger
    this.purchase.total -= productSale.product.price * productSale.quantity;
    this.productsSale.splice(this.productsSale.indexOf(productSale));
  }

  savePurchase(purchase:Purchase){
    let sendProducts : Product[] = new Array();
    this.productsSale.forEach(productSale =>{
      for (let index = 0; index <  productSale.quantity; index++) {
        sendProducts.push(productSale.product);
      }
    });
    
    let purchaseBody : PurchaseBody = {"purchase": this.purchase, "products": sendProducts};
  
    this.purchaseService.create(purchaseBody).subscribe(data =>{
      location.reload();
    });
  }

  close(){
    this.closeModal.emit(false);
  }
}
