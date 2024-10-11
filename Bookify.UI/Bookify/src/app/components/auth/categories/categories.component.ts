import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Category } from 'src/app/models/Category.model';
import { AppService } from 'src/app/services/app.service';
import { CategoryService } from 'src/app/services/Category.Service/category.service';
import { ViewCategoryModalComponent } from '../../Modals/view-category-modal/view-category-modal.component';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements AfterViewInit {
  categoriesTableColumn: string[] = ['name', 'actions'];
  
  dataSource: MatTableDataSource<Category> = new MatTableDataSource;

  @ViewChild(MatPaginator) paginator: MatPaginator | any;
  @ViewChild(MatSort) sort: MatSort | any;

  categories: Category[] = [];

  constructor(private dialog: MatDialog, private appService: AppService, private categoryService: CategoryService) { 
  }
  
  ngAfterViewInit(): void {
    // Check Login Status
    this.appService.CheckUserStatus();
    
    this.categoryService.AllCategory()
    .subscribe({
      next: (categories: any) => {
        this.categories = categories;
        this.dataSource = new MatTableDataSource<Category>(this.categories);

        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error: (err) => {0
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

    this.categoryService.GetCategory(id)
    .subscribe({
      next: (category) => {
        const dialogConfig = new MatDialogConfig();
        dialogConfig.data = category;
        dialogConfig.width = '500px';
        dialogConfig.height = '500px';

        this.dialog.open(ViewCategoryModalComponent, dialogConfig);
      },
      error: (err) => {
        console.log(err);
      }
    });
  }
}
