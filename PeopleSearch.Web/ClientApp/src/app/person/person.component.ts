import { Component, OnInit } from '@angular/core';
import { PersonService } from '../services/person.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {
  persons$: Observable<any>;

  constructor(private personService: PersonService) { }

  ngOnInit() {
      this.persons$ = this.personService.getPersons();
  }

}
