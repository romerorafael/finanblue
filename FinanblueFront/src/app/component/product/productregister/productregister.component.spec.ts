import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductregisterComponent } from './productregister.component';

describe('ProductregisterComponent', () => {
  let component: ProductregisterComponent;
  let fixture: ComponentFixture<ProductregisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductregisterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductregisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
