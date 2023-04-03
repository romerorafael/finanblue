import { Component , OnInit} from '@angular/core';
import { Product } from 'src/app/entities/product/product';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'Product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent implements OnInit{

  public products: Product[] = new Array();
  public showModal: boolean = false;

  constructor(private productService : ProductService){}

  async ngOnInit(){
    this.productService.getAll().subscribe( (data:any)=>{
      this.products = data;
    })
  }

  closeModal(e:any){
    this.showModal= e;
  }
}
