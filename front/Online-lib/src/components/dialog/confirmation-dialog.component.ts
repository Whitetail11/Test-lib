import { Component, Inject, OnInit } from '@angular/core';
import { BookService } from 'src/services/book.service';
import { ToastrService } from 'ngx-toastr';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BooksListComponent } from '../books-list/books-list.component';
import { DialogData } from 'src/models/DialogeData';
@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.scss']
})
export class ConfirmationDialogComponent implements OnInit {

  constructor(
    private bookService: BookService,
    private toastr: ToastrService,
    public dialogRef: MatDialogRef<BooksListComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) { }

  ngOnInit(): void {
  }

  isReturn() {
    return this.data.action === 'return';
  }

  closeDialoge(): void {
    this.dialogRef.close();
  }
}
