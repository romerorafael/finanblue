import { Component, Input } from '@angular/core';
import { Product } from 'src/app/entities/product/product';

@Component({
  selector: 'Productcard',
  templateUrl: './productcard.component.html',
  styleUrls: ['./productcard.component.css']
})
export class ProductcardComponent {
  @Input() product : Product = {id:0, name:"", price:0, description:""};
}
