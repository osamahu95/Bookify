import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Book_BookShop } from 'src/app/interfaces/Book_BookShopInterface.interface';
import { Book } from 'src/app/models/Book.model';
import { Bookshop } from 'src/app/models/Bookshop.model';
import { BookshopService } from 'src/app/services/BookShop.Service/bookshop.service';
import { ToastService } from 'src/app/services/Toast.Service/toast.service';

@Component({
  selector: 'app-add-to-book-shop',
  templateUrl: './add-to-book-shop.component.html',
  styleUrls: ['./add-to-book-shop.component.css']
})
export class AddToBookShopComponent implements OnInit {

  book: Book = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    isbn: '',
    description: '',
    active: false
  };

  activated: Boolean = false;

  bookShops: Bookshop[] = [];
  
  bookShop: Bookshop = {
    id: '00000000-0000-0000-0000-000000000000',
    name: 'No BookShop Assigned',
    address: '',
    description: ''
  }

  bookBookShopInterface: Book_BookShop = {
    bookId: '00000000-0000-0000-0000-000000000000',
    bookShopId: '00000000-0000-0000-0000-000000000000'
  }

  constructor(private bookShopService: BookshopService, private dialogRef: MatDialogRef<AddToBookShopComponent>, 
      @Inject(MAT_DIALOG_DATA) data : any, private toastService: ToastService) {
        this.book = data;
        this.bookBookShopInterface.bookId = this.book.id;
      }

  ngOnInit(): void {
    this.bookShopService.GetBookShopByBookId(this.book.id)
    .subscribe({
      next: (bookShop) => {
        if(bookShop){
          this.bookShop = bookShop;
          this.bookBookShopInterface.bookShopId = this.bookShop.id;

          this.activated = true;
        }
      },
      error: (response) => {
        console.log(response);
      }
    });

    this.bookShopService.AllBookshops()
    .subscribe({
      next: (bookshops) => {
        this.bookShops = bookshops;
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  OnBookShopSelect(id: string){
    this.bookBookShopInterface.bookShopId = id;
  }

  SubmitBookToBookShop(){
    if(this.activated){
      this.bookShopService.UpdateBooktoBookShop(this.bookBookShopInterface)
      .subscribe({
        next: (bookshop) => {
          this.bookShop = bookshop;

          this.toastService.openToast(["Book Updated to the Selected Bookshop Successfully."], "success");
        },
        error: (err) => {
          console.log(err);
          
          this.toastService.openToast(["Failed to Set the following Book to the Selected Bookshop"], "danger");
        }
      });
    }else{
      this.bookShopService.SetBookToBookShop(this.bookBookShopInterface)
      .subscribe({
        next: (bookshop) => {
          this.bookShop = bookshop;
          
          this.toastService.openToast(["Book Assigned to the Selected Bookshop Successfully."], "success");
        },
        error: (err) => {
          console.log(err);

          this.toastService.openToast(["Failed to Set the following Book to the Selected Bookshop"], "danger");
        }
      });
    }
    
  }

}
