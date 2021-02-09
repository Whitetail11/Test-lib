import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Book } from 'src/models/Book';
import { AuthService } from 'src/services/auth.service';
import { BookService } from 'src/services/book.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { BookQueryModel } from 'src/models/BookQueryModel';
import { ConfirmationDialogComponent } from '../dialog/confirmation-dialog.component';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.scss']
})
export class BooksListComponent implements OnInit {
  constructor(
    private authService: AuthService,
    private bookService: BookService,
    private toastr: ToastrService,
    private router: Router,
    public dialog: MatDialog
  ) { }

  books: Book[] = null;
  displayedColumns: string[] = ['name', 'amount', 'available', 'authors', 'users'];
  dataSource: MatTableDataSource<Book>;
  length = 100;
  pageSize = 3;
  pageSizeOptions: number[] = [3, 10, 25, 100];
  model: BookQueryModel;
  pageNumber: number = 1;
  userBooks: Book[] = null

  pageEvent: PageEvent;

  @ViewChild(MatSort) sort; MatSort;

  ngOnInit(): void {
    this.getBooks(this.pageSize, 1);
    this.setTableColumns();
  }

  isUserHasBook(id: number) {
    return this.userBooks.find(book => book.id === id)
  }
  getBooksOfUser() {
    if (this.isLogIn())
      return this.bookService.getUserBooks(this.authService.decodeToken().userid);
  }
  openDialogue(id: number, action: string): void {
    console.log(action);
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      width: '400px',
      data: { bookId: id, userId: this.authService.decodeToken().userid, action }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        action === 'take' ? this.takeBook(id) : this.returnBook(id);
      }
    });
  }

  returnBook(id: number) {
    this.bookService.returnBook(this.authService.decodeToken().userid, id).subscribe(() => {
      this.toastr.success("You successfully return book");
      this.getBooks(this.pageSize, this.pageNumber);
    }, error => {
      this.toastr.error(error.error);
    })
  }

  takeBook(id: number) {
    this.bookService.takeBook(this.authService.decodeToken().userid, id).subscribe(() => {
      this.toastr.success("You successfully taken book");
      this.getBooks(this.pageSize, this.pageNumber);
    }, error => {
      this.toastr.error(error.error);
    })
  }
  getBooksForPageData(event?: PageEvent) {
    this.bookService.getAllBooks({ count: event.pageSize, pageNumber: +event.pageIndex + 1 }).subscribe((res) => {
      this.books = res.books;
      this.dataSource = new MatTableDataSource<Book>(this.books);
      this.dataSource.sort = this.sort;
      this.pageSize = event.pageSize;
      this.pageNumber = +event.pageIndex + 1;
    })
    return event;
  }

  getBooks(pageSize, pageNumber) {
    this.bookService.getAllBooks({ count: pageSize, pageNumber: pageNumber }).subscribe((res) => {
      this.getBooksOfUser().subscribe((getBooksOfUser) => {
          this.userBooks = getBooksOfUser;
          this.books = res.books;
          this.dataSource = new MatTableDataSource<Book>(this.books);
          this.dataSource.sort = this.sort;
          this.length = res.count;
      })
    });
  }
  setTableColumns() {
    if (!this.isAdmin()) {
      this.displayedColumns = ['name', 'amount', 'available', 'authors'];
    }
  }

  isAdmin() {
    return this.authService.isAdmin();
  }

  isLogIn() {
    return this.authService.isAuthenticated();
  }

  logOut() {
    this.authService.logout();
  }
}
