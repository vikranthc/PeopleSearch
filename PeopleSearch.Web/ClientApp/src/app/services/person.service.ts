import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Observable, Subject, BehaviorSubject } from 'rxjs';
import { distinctUntilChanged, switchMap, debounceTime } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  constructor(private http: HttpClient) { }

  //isLoading: BehaviorSubject<boolean> = new BehaviorSubject(false);

  searchPersons$(text$): Observable<any> {
    return text$.pipe(
      debounceTime(1000),
      distinctUntilChanged(),
      switchMap(c => this.searchPersons(c)));

  }

  searchPersons(text) {
    //this.isLoading.next(true);
    var url = `/api/persons?searchText=${text}`;
    return this.http.get(url);
  }

  getPersons(): Observable<any> {
    var url = "/api/persons";
    return this.http.get(url);
  }
}
