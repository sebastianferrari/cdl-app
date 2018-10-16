import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { License } from "./license";

@Injectable()
export class DataService {

  constructor(private http: HttpClient) {

  }

  private token: string = "";
  private tokenExpiration: Date;

  public licenses: License[] = [];

  public get loginRequired(): boolean {
    return this.token.length == 0 || this.tokenExpiration > new Date();
  }

  loadLicenses(): Observable<boolean> {
    return this.http.get("/api/licenses")
      .pipe(
        map((data: any[]) => {
          this.licenses = data;
          return true;
        }));
  }
}