import { Component, OnInit } from '@angular/core';
import { DataService } from '../shared/dataService';
import { License } from '../shared/license';

@Component({
  selector: "licenses-list",
  templateUrl: "list.component.html",
  styleUrls: [ "list.component.css" ]
})

export class LicensesList implements OnInit {

  constructor(private data: DataService) {
    this.licenses = data.licenses;
  }

  public licenses: License[] = [];

  ngOnInit(): void {
    this.data.loadLicenses()
      .subscribe(success => {
        if (success) {
          this.licenses = this.data.licenses;
        }
      });
  }
}