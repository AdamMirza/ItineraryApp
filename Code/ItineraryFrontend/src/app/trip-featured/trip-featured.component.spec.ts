import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TripFeaturedComponent } from './trip-featured.component';

describe('TripFeaturedComponent', () => {
  let component: TripFeaturedComponent;
  let fixture: ComponentFixture<TripFeaturedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TripFeaturedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TripFeaturedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
