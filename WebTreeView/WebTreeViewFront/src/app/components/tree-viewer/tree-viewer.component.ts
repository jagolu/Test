import { Component } from '@angular/core';
import { HttpRequestService } from 'src/app/services/http-request.service';
import { Item } from '../../models/item';

@Component({
  selector: 'app-tree-viewer',
  templateUrl: './tree-viewer.component.html'
})
export class TreeViewerComponent {

  public items:Item[] = [];

  constructor(private _httpService:HttpRequestService){}

  ngOnInit(){
    this._httpService.getFileJsonRetriever<Item[]>("items.json").subscribe((data)=> {
      this.items = data;
      console.log(this.items);
    });
  }
}
