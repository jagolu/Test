import { Component, Input } from '@angular/core';
import { Item } from 'src/app/models/item';

@Component({
  selector: 'app-leave-viewer',
  templateUrl: './leave-viewer.component.html'
})
export class LeaveViewerComponent {

  @Input('leave-item') item:Item = {name : "", children: []};
}
