import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';


import {catchError, map} from 'rxjs/operators';
import {environment} from "../../../environments/environment";
import {Observable, throwError} from "rxjs";
import {Ubigeo} from "../models/Ubigeo";

@Injectable({
  providedIn: 'root'
})
export class UbigeoService {

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


  collectionByRegionAndProvince(codeRegion: string, codeProvince: string): Observable<Ubigeo[]> {

    return this.http.get<any>(`${this.url}/ubigeo/region/${codeRegion}/province/${codeProvince}`, {
      headers: this.headers
    })
      .pipe(
        map((response: any) => {
          const collection: Ubigeo[] = [];
          if (response.status === 200) {
            // OK return data
            response.data.forEach((ele: any) => {
              const model = new Ubigeo();
              model.code = ele.code;
              model.regionCode = ele.regionCode;
              model.provinceCode = ele.provinceCode;
              model.description = ele.description;
              collection.push(model);
            });
            return collection;
          } else {
            throw throwError(response.error);
          }
        }),
        catchError(err => {
          // Network or other error, handle appropriately
          return throwError(err.message);
        })
      );
  }



}
