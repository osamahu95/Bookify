import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  constructor(private snakbar: MatSnackBar) { }

  public openToast(data: any[], type: string){

    let className = "";
    let timeout = 1500;

    if(type === "primary"){
      className = 'primarytoast';
    }else if(type === "danger"){
      className = 'dangertoast';
    }else if(type === "success"){
      className = 'successtoast';
    }
    
    data.forEach((message, index) => {
      setTimeout(() => {
        this.snakbar.open(message, 'Close', {
          duration: timeout,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: [className]
        });
      }, index * (timeout + 500));
    });
  }
}
