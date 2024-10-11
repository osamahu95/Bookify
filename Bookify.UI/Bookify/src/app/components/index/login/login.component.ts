import { Component, OnInit } from '@angular/core';
import { FormControl, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthResponse } from 'src/app/interfaces/Response/AuthResponse.interface';
import { UserLogin } from 'src/app/interfaces/UserLogin.interface';
import { StorageService } from 'src/app/services/Storage.Service/storage.service';
import { ToastService } from 'src/app/services/Toast.Service/toast.service';
import { UserService } from 'src/app/services/User.Service/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  email = new FormControl('', [Validators.required, Validators.email]);
  password = new FormControl('', [Validators.required]);
  hidePassword: boolean = true;

  userLogin: UserLogin = {
    email: '',
    password: ''
  };

  authResponse: AuthResponse = {
    isAuthSuccess: false,
    errorMessage: '',
    token: ''
  }

  constructor(private userService: UserService, private toastService: ToastService, 
      private storageService: StorageService, private router: Router) { }

  ngOnInit(): void {
    
  }

  Login(login: NgForm){
    this.userService.Login(this.userLogin)
    .subscribe({
      next: (response: any) => {
        this.authResponse = response;

        this.storageService.Save('token', this.authResponse.token);

        this.toastService.openToast(["User Login Success"], "success");

        this.router.navigate(['auth']);
      },
      error: (err) => {
        var error = err.error;

        this.authResponse = error;
        this.toastService.openToast([this.authResponse.errorMessage], "danger");
      }
    });
  }

  getEmailErrorMessage(){
    if(this.email.hasError('required')){
      return 'Email is Required';
    }

    return this.email.hasError('email') ? 'Not a valid Email': '';
  }

}
