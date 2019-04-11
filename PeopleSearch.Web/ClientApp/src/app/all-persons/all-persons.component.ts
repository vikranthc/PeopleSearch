import { Component, OnInit } from '@angular/core';
import { PersonService } from '../services/person.service';
import { Observable } from 'rxjs';
import { tap, map } from 'rxjs/operators';


@Component({
  selector: 'app-all-persons',
  templateUrl: './all-persons.component.html',
  styleUrls: ['./all-persons.component.css']
})
export class AllPersonsComponent implements OnInit {
  searchResult$: Observable<any>;

  isLoading: boolean;
  constructor(private personService: PersonService) { }

  ngOnInit() {
      this.searchResult$ = this.personService.getAllPersons().pipe(
          tap(c => this.isLoading = true),
          tap(c => console.log("loading")),
          map(c=>c),
          tap(c => console.log("loaded")),
          tap(d=> this.isLoading = false)
          );
  
  }

}
