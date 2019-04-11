import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'person-display-card',
  templateUrl: './person-display-card.component.html',
  styleUrls: ['./person-display-card.component.css']
})
export class PersonDisplayCardComponent implements OnInit {

  @Input()
  person:any;

  constructor() { }

  ngOnInit() {
  }

}
