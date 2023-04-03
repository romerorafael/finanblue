import { Component, Input } from '@angular/core';
import { Company } from 'src/app/entities/company/company';

@Component({
  selector: 'CompanyCard',
  templateUrl: './companycard.component.html',
  styleUrls: ['./companycard.component.css']
})


export class CompanycardComponent{

  @Input() company : Company = {id:0, name:"", cnpj:"", activity:""};

}
