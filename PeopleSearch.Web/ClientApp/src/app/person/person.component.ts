import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { PersonService } from '../services/person.service';
import { Observable, Subject } from 'rxjs';
import { tap, debounceTime, map, switchMap } from 'rxjs/operators';

@Component({
  selector: 'person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css'],
})
export class PersonComponent implements OnInit {
  persons$: Observable<any>;
  searchResult$ : Observable<any>;
  isLoading = false;
  searchText$ = new Subject<string>();

  constructor(private personService: PersonService) { }

  ngOnInit() {
    this.persons$ = this.personService.getPersons();
    this.searchResult$ =
    this.searchText$.pipe(
        debounceTime(1000),
        tap(c=>this.isLoading=true),
        tap(d => console.log("isLoading " + this.isLoading) ),
        switchMap(c => this.personService.searchPersons(c)),
        tap(c=> this.isLoading=false),
        tap(c => console.log("done laoding " + this.isLoading)),
    );
  }
}
