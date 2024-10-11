import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Author } from 'src/app/models/Author.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

  constructor(private http: HttpClient) { }

  public AllAuthors(): Observable<Author[]>{
    return this.http.get<Author[]>("api/Author/AllUserAuthor");
  }

  public Add(body: Author): Observable<Author>{
    return this.http.post<Author>("api/Author", body);
  }

  public Update(body: Author): Observable<Author>{
    return this.http.put<Author>("api/Author", body);
  }

  public Delete(id: string){
    return this.http.delete(`api/Author/${id}`);
  }

  public GetAuthor(id: string): Observable<Author>{
    return this.http.get<Author>(`api/Author/${id}`);
  }

  public GetBookAuthor(id: string): Observable<Author>{
    return this.http.get<Author>(`api/Author/AuthorBook/${id}`);
  }
}
