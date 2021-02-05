import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToReturnDialogComponent } from './to-return-dialog.component';

describe('ToReturnDialogComponent', () => {
  let component: ToReturnDialogComponent;
  let fixture: ComponentFixture<ToReturnDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ToReturnDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ToReturnDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
