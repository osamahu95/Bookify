import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from 'src/app/models/Category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  public AllCategory(): Observable<Category[]>{
    return this.http.get<Category[]>("api/Category");
  }

  public GetCategory(id: string){
    return this.http.get(`api/category/${id}`);
  }

  public GetBookCategoires(id: string): Observable<Category[]>{
    return this.http.get<Category[]>(`api/Category/AllBookCategories/${id}`);
  }
}
