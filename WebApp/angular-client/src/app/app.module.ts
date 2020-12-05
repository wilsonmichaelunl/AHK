import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

import { ScriptModule } from './scripts/script.module';
import { AboutComponent } from './home/about/about.component';
import { InstructionsComponent } from './home/instructions/instructions.component';
import { FavoriteScriptFormComponent } from './scripts/favorite-script-form/favorite-script-form.component';
import { PresetScriptFormComponent } from './scripts/preset-script-form/preset-script-form.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    InstructionsComponent,
    FavoriteScriptFormComponent,
    PresetScriptFormComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent },
      { path: 'home/instructions', component: InstructionsComponent },
      { path: 'home/about', component: AboutComponent },
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: '**', redirectTo: 'home', pathMatch: 'full' }
    ]),
    ScriptModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
