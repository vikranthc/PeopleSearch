import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { PersonService } from '../services/person.service';
import { Observable, Subject } from 'rxjs';
import { tap, debounceTime, map, switchMap, filter } from 'rxjs/operators';

@Component({
  selector: 'person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css'],
})
export class PersonSearchComponent implements OnInit {
  searchResult$ : Observable<any>;
  searchText$ = new Subject<string>();

  isLoading = false;

  constructor(private personService: PersonService) { }

  ngOnInit() {
    this.searchResult$ =
        this.searchText$.pipe(
            debounceTime(500),                             // wait half a second for the user to stop typing 
            filter(c => { return c.trim().length > 0; }),  // Do not search for empty strings
            tap(c=>this.isLoading=true),
            switchMap(c => this.personService.searchPersons(c)),
            tap(c=> this.isLoading=false),
        );
  }
}
