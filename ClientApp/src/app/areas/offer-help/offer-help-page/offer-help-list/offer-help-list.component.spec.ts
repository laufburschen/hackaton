import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OfferHelpListComponent } from './offer-help-list.component';

describe('OfferHelpListComponent', () => {
  let component: OfferHelpListComponent;
  let fixture: ComponentFixture<OfferHelpListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OfferHelpListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OfferHelpListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
