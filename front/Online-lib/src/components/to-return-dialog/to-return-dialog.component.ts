import { Component, Inject, OnInit } from '@angular/core';
import { BookService } from 'src/services/book.service';
import { ToastrService } from 'ngx-toastr';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BooksListComponent } from '../books-list/books-list.component';
import { DialogData } from 'src/models/DialogeData';
@Component({
  selector: 'app-to-return-dialog',
  templateUrl: './to-return-dialog.component.html',
  styleUrls: ['./to-return-dialog.component.scss']
})
export class ToReturnDialogComponent implements OnInit {

  constructor(
    private bookService: BookService,
    private toastr: ToastrService,
    public dialogRef: MatDialogRef<BooksListComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) { }

  ngOnInit(): void {
  }

  returnBook() {
    this.bookService.returnBook(this.data.userId, this.data.bookId).subscribe(() => {
      this.toastr.success("You successfully return book");
      this.closeDialoge();
    }, error => {
      this.toastr.error(error.error);
      this.closeDialoge();
    })
  }


  closeDialoge(): void {
    this.dialogRef.close();
  }
}
