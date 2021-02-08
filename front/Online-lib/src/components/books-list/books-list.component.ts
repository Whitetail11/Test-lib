import { Component, OnInit } from '@angular/core';
import { Book } from 'src/models/Book';
import { AuthService } from 'src/services/auth.service';
import { BookService } from 'src/services/book.service';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.scss']
})
export class BooksListComponent implements OnInit {

  constructor(private authService: AuthService, private bookService: BookService) { }

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
    })
  }

  returnBook(id: number) {
    this.bookService.returnBook(this.authService.decodeToken().userid, id).subscribe(() => {
      this.getBooks();
    })
  }

  logOut() {
    this.authService.logout();
  }
}
