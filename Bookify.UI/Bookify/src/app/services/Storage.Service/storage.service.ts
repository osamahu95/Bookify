import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor() { }

  public Save(key: string, data: any){
    localStorage.setItem(key, data);
  }

  public Get(key: string){
    return localStorage.getItem(key);
  }

  public Delete(key: string){
    localStorage.removeItem(key);
  }
}
