import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookInterface } from 'src/app/interfaces/Book.interface';
import { Book } from 'src/app/models/Book.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  public AllBooks(): Observable<Book[]>{
    return this.http.get<Book[]>("api/Book/AllBooks");
  }

  public GetBook(id: string): Observable<Book>{
    return this.http.get<Book>(`api/Book/${id}`);
  }

  public AddBook(bookInterface: BookInterface){
    return this.http.post("api/Book", bookInterface);
  }

  public UpdateBook(bookInterface: BookInterface){
    return this.http.put("api/Book", bookInterface);
  }

  public DeleteBook(id: string){
    return this.http.delete(`api/Book/${id}`);
  }
}
