import { Component, OnInit } from '@angular/core';
import { Purchase } from 'src/app/entities/purchase/purchase';
import { CompanyService } from 'src/app/services/company/company.service';
import { PurchaseService } from 'src/app/services/purchase/purchase.service';

@Component({
  selector: 'Purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css']
})
export class PurchaseComponent implements OnInit{

  public purchases: Purchase[] = new Array();
  public showModal: boolean = false;

  constructor(private purchaseService: PurchaseService, private companyService: CompanyService){
  }
  ngOnInit(): void {
    this.purchaseService.getAll().subscribe(data =>{
      this.purchases = data;
      this.purchases.forEach( purchase =>{
        this.companyService.getById(purchase.companyId).subscribe( company =>{
          purchase.companyName = company.name;
        })
      })
    })
  }

  closeModal(e:any){
    this.showModal= e;
  }
}
