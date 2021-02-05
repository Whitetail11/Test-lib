import { Component, Inject, OnInit } from '@angular/core';
import { AuthService } from 'src/services/auth.service';
import { BookService } from 'src/services/book.service';
import { ToastrService } from 'ngx-toastr';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BooksListComponent } from '../books-list/books-list.component';
import { DialogData } from 'src/models/DialogeData';

@Component({
  selector: 'app-to-take-dialog',
  templateUrl: './to-take-dialog.component.html',
  styleUrls: ['./to-take-dialog.component.scss']
})
export class ToTakeDialogComponent implements OnInit {

  constructor(
    private bookService: BookService,
    private toastr: ToastrService,
    public dialogRef: MatDialogRef<BooksListComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) { }

  ngOnInit(): void {
  }

  takeBook() {
    this.bookService.takeBook(this.data.userId, this.data.bookId).subscribe(() => {
      this.toastr.success("You successfully taken book");
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
