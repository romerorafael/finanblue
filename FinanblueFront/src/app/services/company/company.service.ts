import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Configuration } from 'src/app/app.constants';
import { Company } from 'src/app/entities/company/company';

const apiUrl = Configuration.GetApiUrl() + "api/company";

@Injectable({
  providedIn: 'root'
})

export class CompanyService {
  
  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin' : '*' })
  }

  getAll() : Observable<Company[]>{
    return this.httpClient.get<Company[]>( apiUrl + "/GetAll" )
    .pipe(
      retry(2),
      catchError(this.handleError)
    )
  }

  getById(id:number) : Observable<Company>{
    return this.httpClient.get<Company>(apiUrl + `/GetById/${id}`)
    .pipe(
      retry(2),
      catchError(this.handleError)
    )
  }

  create( company: Company) : Observable<Company>{
    return this.httpClient.post<Company>(apiUrl + `/Post`, JSON.stringify(company), this.httpOptions)
    .pipe(
      retry(2),
      catchError(this.handleError)
    )
  }

  delete( id:number) : Observable<Company>{
    return this.httpClient.delete<Company>(apiUrl + `/Delete/${id}`)
    .pipe(
      retry(2),
      catchError(this.handleError)
    )
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = error.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };
}
