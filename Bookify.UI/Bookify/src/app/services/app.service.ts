import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { StorageService } from './Storage.Service/storage.service';
import { ToastService } from './Toast.Service/toast.service';
import { UserService } from './User.Service/user.service';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(private userService: UserService, private toastService: ToastService, 
    private router: Router, private storageService: StorageService) { }

  public CheckUserStatus(){
    this.userService.CheckLoginStatus()
    .subscribe({
      next: (response) => {
        console.log(response);
      },
      error: (err) => {
        var response = err.error;
        console.log(response);

        let errorMessage: string[] = [];
        
        this.storageService.Delete('token');

        response.errors.forEach((element: any) => {
          errorMessage.push(element);
        });

        this.toastService.openToast(errorMessage, "danger");

        this.router.navigate(['']);
      }
    });
  }
}
