import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {OrderPageComponent} from './order-page.component';
import {OrderStateService} from './order-state.service';

describe('OrderPageComponent', () => {
  let component: OrderPageComponent;
  let fixture: ComponentFixture<OrderPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [OrderPageComponent],
      providers: [OrderStateService],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
