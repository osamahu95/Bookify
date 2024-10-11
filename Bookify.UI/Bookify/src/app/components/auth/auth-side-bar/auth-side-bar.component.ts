import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppService } from 'src/app/services/app.service';

@Component({
  selector: 'app-auth-side-bar',
  templateUrl: './auth-side-bar.component.html',
  styleUrls: ['./auth-side-bar.component.css']
})
export class AuthSideBarComponent implements OnInit {

  constructor(public activeRoute: ActivatedRoute, private appService: AppService) { 
  }

  ngOnInit(): void {
    this.appService.CheckUserStatus();
  }

}
