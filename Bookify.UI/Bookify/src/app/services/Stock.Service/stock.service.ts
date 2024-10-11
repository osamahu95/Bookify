import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookStock } from 'src/app/interfaces/Book_Stock.interface';
import { Stock } from 'src/app/models/Stock.model';

@Injectable({
  providedIn: 'root'
})
export class StockService {

  constructor(private http: HttpClient) { }

  public GetBookStock(bookId: string): Observable<Stock>{
    return this.http.get<Stock>(`api/Stock/${bookId}`);
  }

  public AddStock(stockBookInterface: BookStock): Observable<Stock>{
    return this.http.post<Stock>("api/Stock", stockBookInterface);
  }

  public UpdateStock(stock: Stock): Observable<Stock>{
    return this.http.put<Stock>("api/Stock", stock);
  }
}
