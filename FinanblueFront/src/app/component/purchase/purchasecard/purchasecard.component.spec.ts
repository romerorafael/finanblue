import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchasecardComponent } from './purchasecard.component';

describe('PurchasecardComponent', () => {
  let component: PurchasecardComponent;
  let fixture: ComponentFixture<PurchasecardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PurchasecardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PurchasecardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
