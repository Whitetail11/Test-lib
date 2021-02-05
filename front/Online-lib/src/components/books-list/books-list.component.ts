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
import { ToTakeDialogComponent } from '../to-take-dialog/to-take-dialog.component';
import { ToReturnDialogComponent } from '../to-return-dialog/to-return-dialog.component';

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
  displayedColumnsForUser: string[] = ['name', 'amount', 'available', 'authors'];
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
    this.getBooksOfUser();
  }

  isUserHasBook(id: number) {
    let res = false;
    this.userBooks.forEach(book => {
      if (book.id === id)
        res = true;
    });
    return res;
  }
  getBooksOfUser() {
    this.bookService.getUserBooks(this.authService.decodeToken().userid).subscribe((res) => {
      this.userBooks = res;
    })
  }
  openDialogueToTake(id: number): void {
    const dialogRef = this.dialog.open(ToTakeDialogComponent, {
      width: '400px',
      data: { bookId: id, userId: this.authService.decodeToken().userid }
    });
    dialogRef.afterClosed().subscribe(result => {
      this.getBooks(this.pageSize, this.pageNumber);
      this.getBooksOfUser();
    });
  }
  openDialogueToReturn(id: number): void {
    const dialogRef = this.dialog.open(ToReturnDialogComponent, {
      width: '400px',
      data: { bookId: id, userId: this.authService.decodeToken().userid }
    });
    dialogRef.afterClosed().subscribe(result => {
      this.getBooks(this.pageSize, this.pageNumber);
      this.getBooksOfUser();
    });
  }
  getBooksForPageData(event?: PageEvent) {
    this.bookService.getAllBooks({ count: event.pageSize, pageNumber: +event.pageIndex + 1 }).subscribe((res) => {
      this.books = res;
      this.dataSource = new MatTableDataSource<Book>(this.books);
      this.dataSource.sort = this.sort;
      this.pageSize = event.pageSize;
      this.pageNumber = +event.pageIndex + 1;
    })
    return event;
  }

  getBooks(pageSize, pageNumber) {
    this.bookService.getAllBooks({ count: pageSize, pageNumber: pageNumber }).subscribe((res) => {
      this.books = res;
      this.dataSource = new MatTableDataSource<Book>(this.books);
      this.dataSource.sort = this.sort;
      this.bookService.getCount().subscribe((res) => {
        this.length = res;
      })
    });
  }
  toLog() {
    this.router.navigate(['login']);
  }

  isAdmin() {
    return this.authService.isAdmin();
  }
  toReg() {
    this.router.navigate(['register']);
  }
  isLogIn() {
    return this.authService.isAuthenticated();
  }
  logOut() {
    this.authService.logout();
  }
}
