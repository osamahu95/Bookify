import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StorageService } from 'src/app/services/Storage.Service/storage.service';
import { UserService } from 'src/app/services/User.Service/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  year: string = "";
  date: Date = new Date();

  constructor(private userService: UserService, private router: Router, private storageService: StorageService) {
  }

  ngOnInit(): void {
    
    this.userService.CheckLoginStatus()
    .subscribe({
      next: (response) => {
        this.router.navigate(['auth']);
      },
      error: (response) => {

        this.storageService.Delete('token');
        this.router.navigate(['']);
      }
    });

    this.year = this.date.getFullYear().toString();
  }

}
