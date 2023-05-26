import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { QuickAccess } from 'src/app/shared/QuickAccess.model';
import { QuickAccessService } from 'src/app/shared/QuickAccess.service';
@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  constructor(
    public QuickAccessService: QuickAccessService,
  ) { }

  ngOnInit(): void {
    this.getToList();
  }
  getToList() {
    this.QuickAccessService.GetByParentIDToListAsync(environment.ShopID).subscribe(
      res => {
        this.QuickAccessService.list = (res as QuickAccess[]).sort((a, b) => (a.SortOrder > b.SortOrder ? 1 : -1));
      },
      err => {
      }
    );
  }

}
