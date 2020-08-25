import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { IRunOnOpenConfiguration } from './run-on-open-configuration';
import { saveAs } from 'file-saver';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  apiEndpoint: string = environment.apiEndpoint;

  constructor(private http: HttpClient) { }

  postRunOnOpenFavorites(configurationModel: IRunOnOpenConfiguration): void {
    this.http.post(`${this.apiEndpoint}/Script/CreateRunOnOpenFavoriteScript`, configurationModel,
     { responseType: 'blob'}).subscribe(blob => {
      saveAs(blob, `${configurationModel.FileName}.ahk`);
    });
  }
}
