import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent { 
  welcomeMessage: string = 'Welcome to AHK Scripts For Editors!';
  dropdownValue = '0';
}