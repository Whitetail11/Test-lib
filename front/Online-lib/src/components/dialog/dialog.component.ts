import { Component, Inject, OnInit } from '@angular/core';
import { BookService } from 'src/services/book.service';
import { ToastrService } from 'ngx-toastr';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BooksListComponent } from '../books-list/books-list.component';
import { DialogData } from 'src/models/DialogeData';
@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})
export class DialogComponent implements OnInit {

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
