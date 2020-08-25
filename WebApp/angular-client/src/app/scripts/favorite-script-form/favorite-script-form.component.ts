import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { IRunOnOpenConfiguration } from '../../data/run-on-open-configuration';
import { NgForm } from '@angular/forms';
import { DataService } from '../../data/data.service';

@Component({
  selector: 'app-favorite-script-form',
  templateUrl: './favorite-script-form.component.html',
  styleUrls: ['./favorite-script-form.component.css']
})
export class FavoriteScriptFormComponent implements OnInit {
  @ViewChild('originalX') originalX: ElementRef;

  scriptConfiguration: IRunOnOpenConfiguration = {
    OriginalX: null,
    OriginalY: null,
    NewX: null,
    NewY: null,
    EffectName: null,
    FileName: null
  };
  postError: boolean = false;
  postErrorMessage = '';

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    console.log('in onSubmit: ', form.valid);

    if (form.valid) {
      this.dataService.postRunOnOpenFavorites(this.scriptConfiguration);
      console.log('hi');
      this.postError = false;
    }
    else {
      this.postError = true;
      this.postErrorMessage = 'Please fix the below errors';
    }
  }
}
