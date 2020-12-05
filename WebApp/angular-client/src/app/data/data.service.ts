import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { IRunOnOpenConfiguration } from './run-on-open-configuration';
import { saveAs } from 'file-saver';
import { environment } from '../../environments/environment';
import { FormBuilder, FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  apiEndpoint: string = environment.apiEndpoint;

  constructor(private http: HttpClient) { }

  getRunOnOpenFavorites(configurationModel: IRunOnOpenConfiguration, fileName: string): void {
    console.log(fileName);
    this.http.post(`${this.apiEndpoint}/Script/CreateRunOnOpenFavoriteScript`, configurationModel,
     { responseType: 'blob'}).subscribe(blob => {
      saveAs(blob, `${fileName}.ahk`);
    });
  }

  getRunOnOpenFavorites_New(form: FormGroup, fileName: string): void {
    this.http.post(`${this.apiEndpoint}/Script/CreateRunOnOpenFavoriteScript`, form,
     { responseType: 'blob'}).subscribe(blob => {
      saveAs(blob, `${fileName}.ahk`);
    });
  }

  getRunOnOpenPreset(configurationModel: IRunOnOpenConfiguration): void {
    this.http.post(`${this.apiEndpoint}/Script/CreateRunOnOpenPresetScript`, configurationModel,
     { responseType: 'blob'}).subscribe(blob => {
       saveAs(blob, `${configurationModel.FileName}.ahk`);
    });
  }

  getConfigurationScript(): void {
    this.http.post(`${this.apiEndpoint}/Script/GetConfiguartionScript`, null, { responseType: 'blob'} )
    .subscribe(blob => {
        saveAs(blob, 'configuration.ahk');
    });
  }
}
