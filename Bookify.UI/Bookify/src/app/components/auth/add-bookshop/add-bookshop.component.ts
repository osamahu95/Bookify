import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Bookshop } from 'src/app/models/Bookshop.model';
import { AppService } from 'src/app/services/app.service';
import { BookshopService } from 'src/app/services/BookShop.Service/bookshop.service';
import { ToastService } from 'src/app/services/Toast.Service/toast.service';

@Component({
  selector: 'app-add-bookshop',
  templateUrl: './add-bookshop.component.html',
  styleUrls: ['./add-bookshop.component.css']
})
export class AddBookshopComponent implements OnInit {

  bookShop: Bookshop = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    description: '',
    address: ''
  };

  constructor(private activatedRoute: ActivatedRoute, private toastService: ToastService,
     private router: Router, private bookShopService: BookshopService, private appService: AppService) { }

  ngOnInit(): void {
    // Check Login Status
    this.appService.CheckUserStatus();

    this.activatedRoute.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if(id){
          this.bookShopService.GetBookShop(id)
          .subscribe({
            next: (bookShop) => {
              this.bookShop = bookShop;
            },
            error: (err) => {
              console.log(err);
            }
          });
        }
      }
    });
  }

  AddBookShop(addBookShopForm: NgForm){
    // Check Login Status
    this.appService.CheckUserStatus();
    
    if(this.bookShop.id !== '' && this.bookShop.id !== '00000000-0000-0000-0000-000000000000'){
      this.bookShopService.UpdateBookShop(this.bookShop)
      .subscribe({
        next: (bookShop) => {
          addBookShopForm.reset();
          this.toastService.openToast(["Bookshop Updated Successfully"], "success");

          this.router.navigate(['', 'auth', 'bookshops']);
        },
        error: (err) => {
          console.log(err);

          let errorMessage: string[] = [];

          if(err.error.hasOwnProperty('errors')){
            var errors = err.error.errors;

            for(var property in errors){
              let errorList = errors[property];

              errorList.forEach((item: any) => {
                errorMessage.push(item);
              });
            }
          }

          if(err.status === 400){
            errorMessage.push("Bad Request");
          }

          this.toastService.openToast(errorMessage, "danger");
        }
      });
    }else{
      this.bookShopService.AddBookShop(this.bookShop)
      .subscribe({
        next: (bookShop) => {
          addBookShopForm.reset();
          this.toastService.openToast(["Bookshop Added Successfully"], "success");

          this.router.navigate(['', 'auth', 'bookshops']);
        },
        error: (err) => {
          console.log(err);

          let errorMessage: string[] = [];

          if(err.error.hasOwnProperty('errors')){
            var errors = err.error.errors;

            for(var property in errors){
              let errorList = errors[property];

              errorList.forEach((item: any) => {
                errorMessage.push(item);
              });
            }
          }

          if(err.status === 400){
            errorMessage.push("Bad Request");
          }

          this.toastService.openToast(errorMessage, "danger");
        }
      });
    }
  }

}
