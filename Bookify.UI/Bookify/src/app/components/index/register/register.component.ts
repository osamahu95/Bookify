import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { Router } from '@angular/router';
import { User } from 'src/app/interfaces/User.interface';

import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter } from '@angular/material-moment-adapter';

import * as _moment from 'moment';
import {default as _rollupMoment, Moment} from 'moment';

import { MatDatepicker } from '@angular/material/datepicker';
import { UserService } from 'src/app/services/User.Service/user.service';
import { RegisterResponse } from 'src/app/interfaces/Response/RegisterResponse.interface';
import { ToastService } from 'src/app/services/Toast.Service/toast.service';

const moment = _rollupMoment || _moment;
export const CardExpirationDateFormat = {
  parse: {
    dateInput: 'MM/YY'
  },
  display:{
    dateInput: 'MM/YYYY',
    monthYearLabel: 'MMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY',
  }
};

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers: [
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS]
    },
    {
      provide: MAT_DATE_FORMATS,
      useValue: CardExpirationDateFormat
    }
  ]
})

export class RegisterComponent implements OnInit {

  hidePassword: Boolean = true;
  hideConfirmPassword: Boolean = true;

  // set expiration date picker configuration

  setMonthAndYear(normalizedMonthAndYear: Moment, datepicker: MatDatepicker<Moment>){

    var date = this.creditCardFormGroup.controls.expiry;

    const dateControl = date.value!;
    dateControl.month(normalizedMonthAndYear.month());
    dateControl.year(normalizedMonthAndYear.year());
    date.setValue(dateControl);
    datepicker.close();
  }

  user: User = {
    id: "00000000-0000-0000-0000-000000000000",
    firstName: '',
    lastName: '',
    age: 0,
    email: '',
    password: '',
    confirmPassword: '',
    addressLine1: '',
    addressLine2: '',
    state: '',
    city: '',
    country: '',
    zipCode: '',
    cardOwner: '',
    creditCardNumber: '',
    cvv: '',
    expiration: ''
  };

  registerResponse: RegisterResponse = {
    isSuccessfulRegister: false,
    errors: []
  }

  generalFormGroup = this._formBuilder.group({
    firstname: ['', Validators.required],
    lastname: [''],
    age: [''],
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required],
    confirmpassword: ['', Validators.required]
  });

  addressFormGroup = this._formBuilder.group({
    addressline1: ['', Validators.required],
    addressline2: [''],
    state: ['', Validators.required],
    city: ['', Validators.required],
    country: ['', Validators.required],
    zipcode: ['', Validators.required],
  });

  creditCardFormGroup = this._formBuilder.group({
    owner: ['', Validators.required],
    ccn: ['', Validators.required],
    cvv: ['', Validators.required],
    expiry: [moment(), Validators.required]
  });

  userInfoFormGroup = this._formBuilder.group({
  });

  constructor(private _formBuilder: FormBuilder, private toastService: ToastService, 
    private router: Router, private userService: UserService) { }

  ngOnInit(): void {
  }

  GetEmailError(){
    let emailInp = this.generalFormGroup.controls.email;
    return emailInp.hasError('email') ? 'Not a valid Email': '';
  }

  SetDateToModel(){
    let finalDate = this.creditCardFormGroup.controls.expiry.value?.toDate();

    if(finalDate !== undefined){

      var month = finalDate?.getMonth();
      var year = finalDate?.getFullYear();

      this.user.expiration = (month + 1) + "/" + year;
    }
  }

  Submit(){

    this.userService.Register(this.user)
    .subscribe({
      next: (response: any) => {
        this.registerResponse = response;
        
        if(this.registerResponse.isSuccessfulRegister){
          this.toastService.openToast(["SignUp Successful"], "primary");
          
          this.router.navigate(['confirm']);
        }
      },
      error: (err) => {
        var error = err.error;
        
        let errorMessage: string[] = [];

        if(error.hasOwnProperty('errors')){
          this.registerResponse = error;

          if(this.registerResponse.errors.length > 0){
            this.registerResponse.errors.forEach(message => {
              errorMessage.push(message);
            });
          }else{
            // validation errors
            for (var er in error.errors){
              let errorSet = error.errors[er];
  
              errorSet.forEach((message: string) => {
                errorMessage.push(message);
              });
            }
          }
        }

        this.toastService.openToast(errorMessage, "danger");
      }
    });

  }

}
