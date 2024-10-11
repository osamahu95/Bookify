import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Author } from 'src/app/models/Author.model';

@Component({
  selector: 'app-view-author-modal',
  templateUrl: './view-author-modal.component.html',
  styleUrls: ['./view-author-modal.component.css']
})
export class ViewAuthorModalComponent implements OnInit {

  author: Author = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    description: ''
  };

  constructor(private dialogRef: MatDialogRef<ViewAuthorModalComponent>, @Inject(MAT_DIALOG_DATA) data : any) { 
    this.author = data;
  }

  ngOnInit(): void {
  }

}
