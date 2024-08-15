import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';


import {catchError, map} from 'rxjs/operators';
import {environment} from "../../../environments/environment";
import {Observable, throwError} from "rxjs";
import {Province} from "../models/Province";

@Injectable({
  providedIn: 'root'
})
export class ProvinceService {

  url: string;
  headers: HttpHeaders;

  constructor(
    private http: HttpClient,
  ) {
    this.url = environment.url;
    this.headers = new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8; multipart/form-data',
      'Cache-Control': 'no-cache',
      Pragma: 'no-cache',
      Expires: 'Sat, 01 Jan 2000 00:00:00 GMT'
    });
  }


  collectionByRegion(codeRegion: string): Observable<Province[]> {

    return this.http.get<any>(`${this.url}/province/region/${codeRegion}`, {
      headers: this.headers
    })
      .pipe(
        map((response: any) => {
          const collection: Province[] = [];
          if (response.status === 200) {
            // OK return data
            response.data.forEach((ele: any) => {
              const model = new Province();
              model.code = ele.code;
              model.regionCode = ele.regionCode;
              model.description = ele.description;
              collection.push(model);
            });
            return collection;
          } else {
            return throwError(response.error);
          }
        }),
        catchError(err => {
          // Network or other error, handle appropriately
          return throwError(err.message);
        })
      );
  }



}
