import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Category } from 'src/app/models/Category.model';

@Component({
  selector: 'app-view-category-modal',
  templateUrl: './view-category-modal.component.html',
  styleUrls: ['./view-category-modal.component.css']
})
export class ViewCategoryModalComponent implements OnInit {

  category: Category = {
    id: '00000000-0000-0000-0000-000000000000',
    name: ''
  };

  constructor(private dialogRef: MatDialogRef<ViewCategoryModalComponent>, @Inject(MAT_DIALOG_DATA) data: any) { 
    this.category = data;
  }

  ngOnInit(): void {
  }

}
