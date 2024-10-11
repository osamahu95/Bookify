import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AppService } from 'src/app/services/app.service';
import { StorageService } from 'src/app/services/Storage.Service/storage.service';
import { ToastService } from 'src/app/services/Toast.Service/toast.service';
import { LogoutComponent } from '../../Modals/Confirmation/logout/logout.component';

@Component({
  selector: 'app-auth-navbar',
  templateUrl: './auth-navbar.component.html',
  styleUrls: ['./auth-navbar.component.css']
})
export class AuthNavbarComponent implements OnInit {

  constructor(private storageService: StorageService, private matDialog: MatDialog, 
    private toastService: ToastService, private router: Router, private appService: AppService) { }

  ngOnInit(): void {
    // Check Login Status
    this.appService.CheckUserStatus();
  }

  Logout(){
    
    const dialogRef = this.matDialog.open(LogoutComponent, {
      width: '500px',
    });

    dialogRef.afterClosed().subscribe(result => {
      var dialogResult = result;

      if(dialogResult){
        this.storageService.Delete('token');
        this.toastService.openToast(['Logged out Successfully'], "primary");
        this.router.navigate(['']);
      }
    });
  }

}
