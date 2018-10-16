import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from "./app.component";
import { LicensesList } from "./dashboard/list.component";
import { Dashboard } from "./dashboard/dashboard.component";
import { DataService } from "./shared/dataService";

import { RouterModule } from "@angular/router";

let routes = [
  { path: "", component: Dashboard }//,
  //{ path: "/checkout", component: Checkout }
];

@NgModule({
  declarations: [
    AppComponent,
    LicensesList,
    Dashboard
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(routes, {
      useHash: true,
      enableTracing: false // for debugging of the routes
    })
  ],
  providers: [
    DataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
