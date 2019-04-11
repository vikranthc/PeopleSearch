import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonDisplayCardComponent } from './person-display-card.component';

describe('PersonDisplayCardComponent', () => {
  let component: PersonDisplayCardComponent;
  let fixture: ComponentFixture<PersonDisplayCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonDisplayCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonDisplayCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
