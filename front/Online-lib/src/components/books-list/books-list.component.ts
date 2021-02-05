import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Book } from 'src/models/Book';
import { AuthService } from 'src/services/auth.service';
import { BookService } from 'src/services/book.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { BookQueryModel } from 'src/models/BookQueryModel';

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
      private router: Router
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

  pageEvent: PageEvent;

  @ViewChild(MatSort) sort; MatSort;

  ngOnInit(): void {
    this.getBooks(this.pageSize,1);
  }

  getBooksForPageData(event?:PageEvent) {
    this.bookService.getAllBooks({count: event.pageSize, pageNumber:+event.pageIndex + 1 }).subscribe((res) => {
      this.books = res;
      this.dataSource = new MatTableDataSource<Book>(this.books);
      this.dataSource.sort = this.sort;
      this.pageSize = event.pageSize;
      this.pageNumber = event.pageIndex;
    })
    return event;
  }
  
  getBooks(pageSize, pageNumber) {
    this.bookService.getAllBooks({count: pageSize, pageNumber: pageNumber}).subscribe((res) => {
      this.books = res;
      this.dataSource = new MatTableDataSource<Book>(this.books);
      this.dataSource.sort = this.sort;
      this.bookService.getCount().subscribe((res) => {
        this.length = res;
      })
    });
  }
  
  takeBook(id: number) {
    this.bookService.takeBook(this.authService.decodeToken().userid, id).subscribe(() => {
      this.getBooks(this.pageSize, this.pageNumber);
      this.toastr.success("You successfully taken book");
    }, error => {
      this.toastr.error(error.error);
    })
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
  returnBook(id: number) {
    this.bookService.returnBook(this.authService.decodeToken().userid, id).subscribe(() => {
      this.getBooks(this.pageSize, this.pageNumber);
      this.toastr.success("You successfully return book");
    }, error => {
      this.toastr.error(error.error);
    })
  }

  isLogIn() {
    return this.authService.isAuthenticated();
  }
  logOut() {
    this.authService.logout();
  }
}
