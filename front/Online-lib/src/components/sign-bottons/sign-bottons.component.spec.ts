import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignBottonsComponent } from './sign-bottons.component';

describe('SignBottonsComponent', () => {
  let component: SignBottonsComponent;
  let fixture: ComponentFixture<SignBottonsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SignBottonsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SignBottonsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
