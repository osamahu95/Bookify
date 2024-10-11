import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book_BookShop } from 'src/app/interfaces/Book_BookShopInterface.interface';
import { Book } from 'src/app/models/Book.model';
import { Bookshop } from 'src/app/models/Bookshop.model';

@Injectable({
  providedIn: 'root'
})
export class BookshopService {

  constructor(private http: HttpClient) { }

  public AllBookshops(): Observable<Bookshop[]>{
    return this.http.get<Bookshop[]>("api/Bookshop/AllUserBookshop");
  }

  public AddBookShop(body: Bookshop): Observable<Bookshop>{
    return this.http.post<Bookshop>("api/Bookshop", body);
  }

  public UpdateBookShop(body: Bookshop): Observable<Bookshop>{
    return this.http.put<Bookshop>("api/Bookshop", body);
  }

  public DeleteBookshop(id: string){
    return this.http.delete(`api/Bookshop/${id}`);
  }

  public GetBookShop(id: string): Observable<Bookshop>{
    return this.http.get<Bookshop>(`api/Bookshop/${id}`);
  }

  public GetBookShopByBookId(bookId: string): Observable<Bookshop>{
    return this.http.get<Bookshop>(`api/Bookshop/GetBookShopbyBook/${bookId}`);
  }

  public SetBookToBookShop(body: Book_BookShop): Observable<Bookshop>{
    return this.http.put<Bookshop>("api/Bookshop/AddBookToBookShop", body);
  }

  public UpdateBooktoBookShop(body: Book_BookShop): Observable<Bookshop>{
    return this.http.put<Bookshop>("api/Bookshop/UpdateBookToBookShop", body);
  }

  public GetBooksByBookShip(id: string): Observable<Book[]>{
    return this.http.get<Book[]>(`api/Bookshop/GetBooksByBookshop/${id}`);
  }
}
