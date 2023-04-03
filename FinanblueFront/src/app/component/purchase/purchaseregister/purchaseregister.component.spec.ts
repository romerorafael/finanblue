import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseregisterComponent } from './purchaseregister.component';

describe('PurchaseregisterComponent', () => {
  let component: PurchaseregisterComponent;
  let fixture: ComponentFixture<PurchaseregisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PurchaseregisterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PurchaseregisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
