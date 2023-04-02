import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Configuration } from 'src/app/app.constants';
import { Product } from 'src/app/entities/product/product';

const apiUrl = Configuration.GetApiUrl() + "api/product";

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  
  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin' : '*'  })
  }

  getAll() : Observable<Product[]>{
    return this.httpClient.get<Product[]>( apiUrl + "/GetAll" )
    .pipe(
      retry(2),
      catchError(this.handleError)
    )
  }

  getById(id:number) : Observable<Product>{
    return this.httpClient.get<Product>(apiUrl + `/GetById/${id}`)
    .pipe(
      retry(2),
      catchError(this.handleError)
    )
  }

  create( product: Product) : Observable<Product>{
    return this.httpClient.post<Product>(apiUrl + `/Post`, JSON.stringify(product), this.httpOptions)
    .pipe(
      retry(2),
      catchError(this.handleError)
    )
  }

  delete( id:number) : Observable<Product>{
    return this.httpClient.delete<Product>(apiUrl + `/Delete/${id}`)
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
