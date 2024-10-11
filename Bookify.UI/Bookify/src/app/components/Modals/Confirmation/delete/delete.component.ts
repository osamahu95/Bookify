import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {
  
  dataList: any;

  type: string = "";
  entity: any;

  constructor(private dialogRef: MatDialogRef<DeleteComponent>, @Inject(MAT_DIALOG_DATA) data: any) { 
    this.dataList = data;
  }

  ngOnInit(): void {
    this.type = this.dataList.type;
    this.entity = this.dataList.entity;
  }

  public onConfirm(){
    this.dialogRef.close(true);
  }

  public onDismiss(){
    this.dialogRef.close(false);
  }

}
