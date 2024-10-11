import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Book } from 'src/app/models/Book.model';
import { BookService } from 'src/app/services/Book.Service/book.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ViewBookModalComponent } from '../../Modals/view-book-modal/view-book-modal.component';
import { AddToBookShopComponent } from '../../Modals/add-to-book-shop/add-to-book-shop.component';
import { AddBookComponent } from '../add-book/add-book.component';
import { AddBookStockComponent } from '../../Modals/add-book-stock/add-book-stock.component';
import { ToastService } from 'src/app/services/Toast.Service/toast.service';
import { DeleteComponent } from '../../Modals/Confirmation/delete/delete.component';
import { AppService } from 'src/app/services/app.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements AfterViewInit {
  booksTableColumn: string[] = ['name', 'isbn', 'active', 'actions'];

  dataSource: MatTableDataSource<Book> = new MatTableDataSource;

  @ViewChild(MatPaginator) paginator: MatPaginator | any;
  @ViewChild(MatSort) sort: MatSort | any;


  books: Book[] = [];

  constructor(private dialog: MatDialog, private appService: AppService, private toastService: ToastService, 
    private bookService: BookService) {
  }

  ngAfterViewInit(): void {
    // Check Login Status
    this.appService.CheckUserStatus();

    this.bookService.AllBooks()
    .subscribe({
      next: (books) => {
        this.books = books;
        
        this.dataSource = new MatTableDataSource(this.books);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

  applyFilter(event: Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if(this.dataSource.paginator){
      this.dataSource.paginator.firstPage();
    }
  }

  openViewDialog(id: string){
    // Check Login Status
    this.appService.CheckUserStatus();

    this.bookService.GetBook(id)
    .subscribe({
      next: (book) => {
        const dialogConfig = new MatDialogConfig();
        dialogConfig.data = book;
        dialogConfig.width = '600px';

        this.dialog.open(ViewBookModalComponent, dialogConfig); 
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

  openBookShopDialog(id: string){
    // Check Login Status
    this.appService.CheckUserStatus();

    this.bookService.GetBook(id)
    .subscribe({
      next: (book) => {
        const dialogConfig = new MatDialogConfig();
        dialogConfig.data = book;
        dialogConfig.width = '500px';

        this.dialog.open(AddToBookShopComponent, dialogConfig); 
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

  openBookStockDialog(id: string){
    // Check Login Status
    this.appService.CheckUserStatus();

    this.bookService.GetBook(id)
    .subscribe({
      next: (book) => {
        const dialogConfig = new MatDialogConfig();
        dialogConfig.data = book;
        dialogConfig.width = '500px';

        this.dialog.open(AddBookStockComponent, dialogConfig); 
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

  DeleteBook(id: string){
    // Check Login Status
    this.appService.CheckUserStatus();
    
    let dataList: any = [{
      entity: 'Book'
    }];

    this.books.forEach(book => {
      if(book.id === id){
        dataList.entity = book;
      }  
    });

    const dialogRef = this.dialog.open(DeleteComponent, {
      width: '500px',
      data: dataList
    });

    dialogRef.afterClosed().subscribe(result => {
      var dialogResult = result;

      if(dialogResult){
        this.bookService.DeleteBook(id)
        .subscribe({
          next: (response) => {
            this.toastService.openToast(["Book Deleted Successfully"], "success");

            for(var i=0; i < this.books.length; i++){
              let bookObj = this.books[i];

              if(bookObj.id === id){
                this.books.splice(i, 1);
              }

              this.dataSource.data = this.books;
            }
          },
          error: (response) => {
            this.toastService.openToast(["Book Delete Failed"], "danger");
          }
        });
      }
      
    });
  }

}