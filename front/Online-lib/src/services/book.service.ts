import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from 'src/models/Book';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private httpClient: HttpClient) { }

  api = environment.apiUrl
  getAllBooks(): Observable<Book[]> {
    return this.httpClient.get<Book[]>(`${this.api}book/get`);
  }

  takeBook(userId: string, bookId: number): Observable<{}> {
    return this.httpClient.put(`${this.api}book/take?bookId=${bookId}&userId=${userId}`, '')
  }

  returnBook(userId: string, bookId: number): Observable<{}> {
    return this.httpClient.put(`${this.api}book/return?bookId=${bookId}&userId=${userId}`, '')
  }
}
