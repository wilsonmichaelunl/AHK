import { Component } from '@angular/core';
import { DataService } from '../data/data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  welcomeMessage: string = 'Welcome to AHK Scripts For Editors!';
  dropdownValue = '0';

  constructor(private dataService: DataService) { }

  downloadScript(): void{
    this.dataService.getConfigurationScript();
  }
}
