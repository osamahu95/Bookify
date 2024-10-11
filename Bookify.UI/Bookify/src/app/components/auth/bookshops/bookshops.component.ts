import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Bookshop } from 'src/app/models/Bookshop.model';
import { AppService } from 'src/app/services/app.service';
import { BookshopService } from 'src/app/services/BookShop.Service/bookshop.service';
import { ToastService } from 'src/app/services/Toast.Service/toast.service';
import { DeleteComponent } from '../../Modals/Confirmation/delete/delete.component';
import { ViewBookshopModalComponent } from '../../Modals/view-bookshop-modal/view-bookshop-modal.component';

@Component({
  selector: 'app-bookshops',
  templateUrl: './bookshops.component.html',
  styleUrls: ['./bookshops.component.css']
})
export class BookshopsComponent implements AfterViewInit {
  bookShopTableColumn: string[] = ['name', 'address', 'actions'];

  dataSource: MatTableDataSource<Bookshop> = new MatTableDataSource;

  @ViewChild(MatPaginator) paginator : MatPaginator | any;
  @ViewChild(MatSort) sort : MatSort | any;

  bookShops: Bookshop[] = [];

  constructor(private dialog: MatDialog, private toastService: ToastService, 
    private appService: AppService, private bookShopService: BookshopService) {}
  
  ngAfterViewInit(): void {
    // Check Login Status
    this.appService.CheckUserStatus();

    this.bookShopService.AllBookshops()
    .subscribe({
      next: (bookShops) => {
        this.bookShops = bookShops;
        this.dataSource = new MatTableDataSource<Bookshop>(this.bookShops);

        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error: (err) => {
        console.log(err);
      }
    });
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

    this.bookShopService.GetBookShop(id)
    .subscribe({
      next: (bookShop) => {
        const dialogConfig = new MatDialogConfig();
        dialogConfig.data = bookShop;
        dialogConfig.width = '500px';

        this.dialog.open(ViewBookshopModalComponent, dialogConfig);
      },
      error: (err) => {
        console.log(err);
      }
    });
  }


  DeleteBookShop(id: string){
    // Check Login Status
    this.appService.CheckUserStatus();

    let dataList: any = [{
      entity: 'Bookshop'
    }];

    this.bookShops.forEach(bookShop => {
      if(bookShop.id === id){
        dataList.entity = bookShop;
      }  
    });

    const dialogRef = this.dialog.open(DeleteComponent, {
      width: '500px',
      data: dataList
    });

    dialogRef.afterClosed().subscribe(result => {
      var dialogResult = result;

      if(dialogResult){
        this.bookShopService.DeleteBookshop(id)
        .subscribe({
          next: (response) => {
            this.toastService.openToast(["Bookshop Deleted Successfully"], "success");

            for(var i=0; i < this.bookShops.length; i++){
              let bookShopObj = this.bookShops[i];

              if(bookShopObj.id === id){
                this.bookShops.splice(i, 1);
              }

              this.dataSource.data = this.bookShops;
            }
          },
          error: (err) => {
            if(err.status == 400){
              this.toastService.openToast(["Bad Request"], "danger");

              var errors = err.error.errors;
              this.toastService.openToast(errors, "danger");
            }
          }
        }); 
      }

    });
  }
}
