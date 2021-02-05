import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToTakeDialogComponent } from './to-take-dialog.component';

describe('ToTakeDialogComponent', () => {
  let component: ToTakeDialogComponent;
  let fixture: ComponentFixture<ToTakeDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToTakeDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToTakeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
