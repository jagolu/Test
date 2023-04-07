import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { TreeViewerComponent } from './components/tree-viewer/tree-viewer.component';
import { LeaveViewerComponent } from './components/leave-viewer/leave-viewer.component';

@NgModule({
  declarations: [
    AppComponent,
    TreeViewerComponent,
    LeaveViewerComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
