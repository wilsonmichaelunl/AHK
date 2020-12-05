import { Component, OnInit} from '@angular/core';
import { IRunOnOpenConfiguration } from '../../data/run-on-open-configuration';
import { NgForm, FormGroup, FormBuilder, Validators, AbstractControl, ValidatorFn, FormArray } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';

import { DataService } from '../../data/data.service';

@Component({
  selector: 'app-favorite-script-form',
  templateUrl: './favorite-script-form.component.html'
})
export class FavoriteScriptFormComponent implements OnInit {
  scriptForm: FormGroup;

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

  constructor(private dataService: DataService,
              private fb: FormBuilder) { }

  ngOnInit(): void {
    this.scriptForm = this.fb.group({
      originalX: ['', [Validators.required]],
      originalY: ['', [Validators.required]],
      newX: ['', [Validators.required]],
      newY: ['', [Validators.required]],
      effectName: ['', [Validators.required]],
      fileName: ['', [Validators.required]]
    });
  }

  onSubmit(form: NgForm): void {

    if (form.valid) {
      this.dataService.getRunOnOpenFavorites(this.scriptConfiguration, this.scriptConfiguration.FileName);
      this.postError = false;
    }
    else {
      this.postError = true;
      this.postErrorMessage = 'Please fix the errors below';
    }
  }

  submit(): void {
    if (this.scriptForm.valid) {
      this.scriptConfiguration = this.scriptForm.value;
      // this.dataService.getRunOnOpenFavorites(this.scriptConfiguration, this.scriptForm.get('fileName').value);
      this.dataService.getRunOnOpenFavorites_New(this.scriptForm.value, this.scriptForm.get('fileName').value);
      this.postError = false;
    }
    else {
      this.postError = true;
      this.postErrorMessage = 'Please fix the errors below';
    }
  }
}
