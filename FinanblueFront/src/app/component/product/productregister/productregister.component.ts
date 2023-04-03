import { Component, EventEmitter, Output } from '@angular/core';
import { Product } from 'src/app/entities/product/product';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'Productregister',
  templateUrl: './productregister.component.html',
  styleUrls: ['./productregister.component.css']
})
export class ProductregisterComponent {

  public productModal : Product = {id:0, name:"", price:0, description:""};

  constructor(private productService : ProductService){}

  @Output() closeModal = new EventEmitter();
  
  saveProduct(product:Product){
    this.productService.create(product).subscribe(data =>{
      location.reload();
    });
  }

  close(){
    this.closeModal.emit(false);
  }
}
