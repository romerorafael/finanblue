import { Component } from '@angular/core';
import { Company } from 'src/app/entities/company/company';
import { CompanyService } from 'src/app/services/company/company.service';

@Component({
  selector: 'Company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})

export class CompanyComponent {

  companies: Company[] = new Array();

  constructor(private companyService : CompanyService){}

  ngOnInit(){
    this.companyService.getAll().subscribe(data=>{
      if(data) this.companies = data;
      console.log(data)
    })
  }
}
