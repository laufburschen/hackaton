import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmOrderModalContentComponent } from './confirm-order-modal-content.component';

describe('ConfirmOrderModalContentComponent', () => {
  let component: ConfirmOrderModalContentComponent;
  let fixture: ComponentFixture<ConfirmOrderModalContentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfirmOrderModalContentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfirmOrderModalContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
