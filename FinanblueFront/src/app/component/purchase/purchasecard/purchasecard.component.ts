import { Component, Input } from '@angular/core';
import { Purchase } from 'src/app/entities/purchase/purchase';

@Component({
  selector: 'PurchaseCard',
  templateUrl: './purchasecard.component.html',
  styleUrls: ['./purchasecard.component.css']
})

export class PurchasecardComponent {
  @Input() purchase : Purchase = {id:0, companyId: 0, products:[], total:0}
}
