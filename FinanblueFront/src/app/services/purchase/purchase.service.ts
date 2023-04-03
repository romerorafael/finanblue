import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Configuration } from 'src/app/app.constants';
import { Purchase, PurchaseBody } from 'src/app/entities/purchase/purchase';

const apiUrl = Configuration.GetApiUrl() + "api/purchase";

@Injectable({
  providedIn: 'root'
})
export class PurchaseService {
  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' , 'Access-Control-Allow-Origin' : '*' })
  }

  getAll() : Observable<Purchase[]>{
    return this.httpClient.get<Purchase[]>( apiUrl + "/GetAll" )
    .pipe(
      retry(2),
      catchError(this.handleError)
    )
  }

  getById(id:number) : Observable<Purchase>{
    return this.httpClient.get<Purchase>(apiUrl + `/GetById/${id}`)
    .pipe(
      retry(2),
      catchError(this.handleError)
    )
  }

  create( purchase: PurchaseBody) : Observable<Purchase>{
    return this.httpClient.post<Purchase>(apiUrl + `/Post`, JSON.stringify(purchase), this.httpOptions)
    .pipe(
      retry(2),
      catchError(this.handleError)
    )
  }

  delete( id:number) : Observable<Purchase>{
    return this.httpClient.delete<Purchase>(apiUrl + `/Delete/${id}`)
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
