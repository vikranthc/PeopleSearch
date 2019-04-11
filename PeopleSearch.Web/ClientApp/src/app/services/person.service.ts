import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Observable, Subject, BehaviorSubject } from 'rxjs';
import { distinctUntilChanged, switchMap, debounceTime } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  constructor(private http: HttpClient) { }

  searchPersons(text) {
    var url = `/api/persons?searchText=${text}`;
    return this.http.get(url);
  }

  getAllPersons(): Observable<any> {
    var url = "/api/persons";
    return this.http.get(url);
  }
}
