import { Component, EventEmitter, Output } from '@angular/core';
import { Company } from 'src/app/entities/company/company';
import { CompanyService } from 'src/app/services/company/company.service';

@Component({
  selector: 'Companyregister',
  templateUrl: './companyregister.component.html',
  styleUrls: ['./companyregister.component.css']
})

export class CompanyregisterComponent {
  public companyModal : Company = {id:0, name:"",activity:"",cnpj:""}

  constructor(private companyService : CompanyService){}

  @Output() closeModal = new EventEmitter();
  
  saveCompany(company:Company){
    this.companyService.create(company).subscribe(data =>{
      location.reload();
    });
  }

  close(){
    this.closeModal.emit(false);
  }
}
