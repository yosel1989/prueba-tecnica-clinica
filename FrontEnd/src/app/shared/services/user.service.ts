import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';


import {catchError, map} from 'rxjs/operators';
import {environment} from "../../../environments/environment";
import {Observable, throwError} from "rxjs";
import {User} from "../models/User";

@Injectable({
  providedIn: 'root'
})
export class UserService {

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


  collection(): Observable<User[]> {

    return this.http.get<any>(`${this.url}/user`, {
      headers: this.headers
    })
      .pipe(
        map((response: any) => {
          const collection: User[] = [];
          if (response.status === 200) {
            // OK return data
            response.data.forEach((ele: any) => {
              const model = new User();
              model.documentNumber = ele.documentNumber;

              model.documentTypeId = ele.documentTypeId;
              model.name = ele.name;
              model.fathersLastName = ele.fathersLastName;
              model.mothersLastName = ele.mothersLastName;
              model.address = ele.address;
              model.regionCode = ele.regionCode;
              model.provinceCode = ele.provinceCode;
              model.ubigeoCode = ele.ubigeoCode;
              model.phone = ele.phone;
              model.email = ele.email;
              model.password = ele.password;
              model.active = ele.active;
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

  create(
    model: User
  ): Observable<boolean> {

    return this.http.post<any>(this.url + `/user`, model, {headers: this.headers})
      .pipe(
        map((response: any) => {
          if (response.status === 201) {
            return true;
          } else {
            throw throwError(response.error);
          }
        }),
        catchError(err => {
          // Network or other error, handle appropriately
          return throwError(err);
        })
      );
  }


  update(
    model: User
  ): Observable<boolean> {

    return this.http.put<any>(this.url + `/user/${model.documentNumber}`, model, {headers: this.headers})
      .pipe(
        map((response:any) => {
          if (response.status === 200) {
            return true;
          } else {
            throw throwError(response.error);
          }
        }),
        catchError(err => {
          // Network or other error, handle appropriately
          return throwError(err);
        })
      );
  }

  delete(
    id: string
  ): Observable<boolean> {

    return this.http.delete<any>(this.url + `/user/${id}`, {headers: this.headers})
      .pipe(
        map((response:any) => {
          if (response.status === 200) {
            return true;
          } else {
            throw throwError(response.error);
          }
        }),
        catchError(err => {
          // Network or other error, handle appropriately
          return throwError(err);
        })
      );
  }


  find(id: string): Observable<User> {

    return this.http.get<any>(`${this.url}/user/${id}`, {
      headers: this.headers
    })
      .pipe(
        map((response: any) => {
          if (response.status === 200) {
            // OK return data
            const ele = response.data;
            const model = new User();
            model.documentNumber = ele.documentNumber;

            model.documentTypeId = ele.documentTypeId;
            model.name = ele.name;
            model.fathersLastName = ele.fathersLastName;
            model.mothersLastName = ele.mothersLastName;
            model.address = ele.address;
            model.regionCode = ele.regionCode;
            model.provinceCode = ele.provinceCode;
            model.ubigeoCode = ele.ubigeoCode;
            model.phone = ele.phone;
            model.email = ele.email;
            model.password = ele.password;
            model.active = ele.active;

            return model;

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
