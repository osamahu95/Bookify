import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<LogoutComponent>) { }

  ngOnInit(): void {
  }

  public onConfirm(){
    this.dialogRef.close(true);
  }

  public onDismiss(){
    this.dialogRef.close(false);
  }

}
