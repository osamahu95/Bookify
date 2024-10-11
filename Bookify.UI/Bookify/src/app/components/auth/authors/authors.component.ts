import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Author } from 'src/app/models/Author.model';
import { AppService } from 'src/app/services/app.service';
import { AuthorService } from 'src/app/services/Author.Service/author.service';
import { ToastService } from 'src/app/services/Toast.Service/toast.service';
import { DeleteComponent } from '../../Modals/Confirmation/delete/delete.component';
import { ViewAuthorModalComponent } from '../../Modals/view-author-modal/view-author-modal.component';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements AfterViewInit {
  authorTableColumn: string[] = ['name', 'description', 'actions'];

  dataSource: MatTableDataSource<Author> = new MatTableDataSource;

  authors: Author[] = [];

  constructor(private dialog: MatDialog, private appService: AppService, private toastService: ToastService, private authorService: AuthorService) {
  }

  @ViewChild(MatPaginator) paginator: MatPaginator | any;
  @ViewChild(MatSort) sort: MatSort | any;
  
  ngAfterViewInit(): void {
    // Check Login Status
    this.appService.CheckUserStatus();
    
    this.authorService.AllAuthors()
    .subscribe({
      next: (authors) => {
        this.authors = authors;
        this.dataSource = new MatTableDataSource<Author>(this.authors);

        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  applyFilter(event: Event){
    var filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if(this.dataSource.paginator){
      this.dataSource.paginator.firstPage();
    }
  }

  openViewDialog(id: string){
    // Check Login Status
    this.appService.CheckUserStatus();

    this.authorService.GetAuthor(id)
    .subscribe({
      next: (author) => {
        const dialogConfig = new MatDialogConfig();
        dialogConfig.data = author;
        dialogConfig.width = '500px';

        this.dialog.open(ViewAuthorModalComponent, dialogConfig);
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  DeleteAuthor(id: string){
    // Check Login Status
    this.appService.CheckUserStatus();

    let dataList: any = [{
      entity: 'Author'
    }];

    this.authors.forEach(author => {
      if(author.id === id){
        dataList.entity = author;
      }  
    });
    
    const dialogRef = this.dialog.open(DeleteComponent, {
      width: '500px',
      data: dataList
    });

    dialogRef.afterClosed().subscribe(result => {
      var dialogResult = result;

      if(dialogResult){
        this.authorService.Delete(id)
        .subscribe({
          next: (response: any) => {
            this.toastService.openToast(["Author Deleted Successfully"], "success");

            for(var i=0; i < this.authors.length; i++){
              let authorObj = this.authors[i];

              if(authorObj.id === id){
                this.authors.splice(i, 1);
              }

              this.dataSource.data = this.authors;
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
