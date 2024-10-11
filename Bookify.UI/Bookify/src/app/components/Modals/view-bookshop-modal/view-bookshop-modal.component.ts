import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Book } from 'src/app/models/Book.model';
import { Bookshop } from 'src/app/models/Bookshop.model';
import { BookshopService } from 'src/app/services/BookShop.Service/bookshop.service';

@Component({
  selector: 'app-view-bookshop-modal',
  templateUrl: './view-bookshop-modal.component.html',
  styleUrls: ['./view-bookshop-modal.component.css']
})
export class ViewBookshopModalComponent implements OnInit {

  bookShop: Bookshop = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    description: '',
    address: ''
  };

  books: Book[] = [];

  constructor(private bookShopService: BookshopService, private dialogRef: MatDialogRef<ViewBookshopModalComponent>, @Inject(MAT_DIALOG_DATA) data: any) { 
    this.bookShop = data;
  }

  ngOnInit(): void {
    this.bookShopService.GetBooksByBookShip(this.bookShop.id)
    .subscribe({
      next: (books) => {
        this.books = books;
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

}
