import { Component, OnInit } from '@angular/core';
import { Company } from 'src/app/entities/company/company';
import { CompanyService } from 'src/app/services/company/company.service';

@Component({
  selector: 'Company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})

export class CompanyComponent implements OnInit{

  public companies: Company[] = new Array();
  public showModal: boolean = false;

  constructor(private companyService : CompanyService){}

    ngOnInit() : void{
    this.companyService.getAll().subscribe( (data:any)=>{
      this.companies = data;
    })
  }

  closeModal(e:any){
    this.showModal= e;
  }
  
}
