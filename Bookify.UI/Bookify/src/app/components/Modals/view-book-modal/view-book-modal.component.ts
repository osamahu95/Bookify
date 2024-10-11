import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Author } from 'src/app/models/Author.model';
import { Book } from 'src/app/models/Book.model';
import { Category } from 'src/app/models/Category.model';
import { AuthorService } from 'src/app/services/Author.Service/author.service';
import { CategoryService } from 'src/app/services/Category.Service/category.service';

@Component({
  selector: 'app-view-book-modal',
  templateUrl: './view-book-modal.component.html',
  styleUrls: ['./view-book-modal.component.css']
})
export class ViewBookModalComponent implements OnInit {

  book: Book = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    isbn: '',
    description: '',
    active: false
  };

  author: Author = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    description: ''
  };

  categories: Category[] = [];

  constructor(private dialogRef: MatDialogRef<ViewBookModalComponent>, @Inject(MAT_DIALOG_DATA) data: any, 
    private authorService: AuthorService, private categoryService: CategoryService) { 
    this.book = data;
  }

  ngOnInit(): void {
    this.authorService.GetBookAuthor(this.book.id)
    .subscribe({
      next: (author) => {
        this.author = author;
      },
      error: (err) => {
        console.log(err);
      }
    });

    this.categoryService.GetBookCategoires(this.book.id)
    .subscribe({
      next: (categories) => {
        this.categories = categories;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

}
