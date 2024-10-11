import { Component, OnInit } from '@angular/core';
import { AppService } from 'src/app/services/app.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  year: string = "";
  date: Date = new Date();

  constructor(private appService: AppService) { }

  ngOnInit(): void {
    this.year = this.date.getFullYear().toString();

    this.appService.CheckUserStatus();
  }

}
