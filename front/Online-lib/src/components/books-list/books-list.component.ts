import { Component, OnInit } from '@angular/core';
import { Book } from 'src/models/Book';
import { AuthService } from 'src/services/auth.service';
import { BookService } from 'src/services/book.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

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

  getBooks() {
    this.bookService.getAllBooks().subscribe((res) => {
      this.books = res;
    });
  }
  books: Book[];
  ngOnInit(): void {
    this.getBooks();
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
