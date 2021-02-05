import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from 'src/models/Book';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { BookQueryModel } from 'src/models/BookQueryModel';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private httpClient: HttpClient) { }

  api = environment.apiUrl
  getAllBooks(model: BookQueryModel): Observable<Book[]> {
    return this.httpClient.post<Book[]>(`${this.api}book/get`, model);
  }

  takeBook(userId: string, bookId: number): Observable<{}> {
    return this.httpClient.put(`${this.api}book/take?bookId=${bookId}&userId=${userId}`, '')
  }

  returnBook(userId: string, bookId: number): Observable<{}> {
    return this.httpClient.put(`${this.api}book/return?bookId=${bookId}&userId=${userId}`, '')
  }
  getCount(): Observable<number> {
    return this.httpClient.get<number>(`${this.api}book/count`);
  }
}
