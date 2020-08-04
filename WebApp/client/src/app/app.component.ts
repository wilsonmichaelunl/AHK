import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IRunOnOpenScriptConfigurationModel } from './models/runOnOpenScriptConfigurationModel';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'AHK Scripts For Editors';
  products: IRunOnOpenScriptConfigurationModel[];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/script').subscribe((response: IRunOnOpenScriptConfigurationModel[]) => {
      this.products = response;
      console.log(response);
    }, error => {
      console.log(error);
    });
  }
}
