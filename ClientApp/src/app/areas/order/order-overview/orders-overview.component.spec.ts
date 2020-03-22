import {async, ComponentFixture, TestBed} from '@angular/core/testing';
import {OrdersOverviewComponent} from './orders-overview.component';

describe('OrderOverviewComponent', () => {
  let component: OrdersOverviewComponent;
  let fixture: ComponentFixture<OrdersOverviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [OrdersOverviewComponent],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrdersOverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
