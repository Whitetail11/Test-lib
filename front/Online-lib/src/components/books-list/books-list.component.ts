import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Book } from 'src/models/Book';
import { AuthService } from 'src/services/auth.service';
import { BookService } from 'src/services/book.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';

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

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort; MatSort;

  ngOnInit(): void {
    this.getBooks();
  }
  getBooks() {
    this.bookService.getAllBooks().subscribe((res) => {
      this.books = res;
      this.dataSource = new MatTableDataSource<Book>(this.books);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });
  }


  takeBook(id: number) {
    this.bookService.takeBook(this.authService.decodeToken().userid, id).subscribe(() => {
      this.getBooks();
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
      this.getBooks();
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
