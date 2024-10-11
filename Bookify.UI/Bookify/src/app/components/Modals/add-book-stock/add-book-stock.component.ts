import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSliderChange } from '@angular/material/slider';
import { BookStock } from 'src/app/interfaces/Book_Stock.interface';
import { Book } from 'src/app/models/Book.model';
import { Stock } from 'src/app/models/Stock.model';
import { StockService } from 'src/app/services/Stock.Service/stock.service';
import { ToastService } from 'src/app/services/Toast.Service/toast.service';

@Component({
  selector: 'app-add-book-stock',
  templateUrl: './add-book-stock.component.html',
  styleUrls: ['./add-book-stock.component.css']
})
export class AddBookStockComponent implements OnInit {

  book: Book = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    isbn: '',
    description: '',
    active: false
  };

  stock: Stock = {
    id: '00000000-0000-0000-0000-000000000000',
    itemStock: 0
  }

  constructor(private stockService: StockService, private dialogRef: MatDialogRef<AddBookStockComponent>, 
    @Inject(MAT_DIALOG_DATA) data : any, private toastService: ToastService) {
      this.book = data;
    }

  ngOnInit(): void {
    this.stockService.GetBookStock(this.book.id)
    .subscribe({
      next: (stock) => {
        if(stock)
          this.stock = stock;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  OnChangeStock(type: string){
    if(type === 'add'){
      this.stock.itemStock +=1;
    }else if(type === 'reduce'){
      this.stock.itemStock > 0 ? this.stock.itemStock -=1 : 0;
    }
  }

  OnsliderChange(event: MatSliderChange){
    let value = event.value;
    if(value != null){
      this.stock.itemStock = value;
    }
  }

  SliderFormatLabel(value: number){
    if(value >= 1000){
      return Math.round(value / 1000) + 'k';
    }

    return value;
  }

  AddStock(){
    if(this.stock.id !== '00000000-0000-0000-0000-000000000000'){
      // Update Stock
      this.stockService.UpdateStock(this.stock)
      .subscribe({
        next: (stock) => {
          this.stock = stock;

          this.toastService.openToast(["Stock Updated Successfully."], "success");
        },
        error: (err) => {
          console.log(err);
        }
      })
    }else{
      let bookStock: BookStock = {
        stock: this.stock,
        bookId: this.book.id
      };

      this.stockService.AddStock(bookStock)
      .subscribe({
        next: (stock) => {
          this.stock = stock;

          this.toastService.openToast(["Stock Created Successfully"], "success");
        },
        error: (err) => {
          console.log(err);
        }
      });
    }
  }

}
