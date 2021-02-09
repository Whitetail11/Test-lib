import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from 'src/models/Book';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { BookQueryModel } from 'src/models/BookQueryModel';
import { ReqViewModel } from 'src/models/ReqViewModel';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private httpClient: HttpClient) { }

  api = environment.apiUrl
  getAllBooks(model: BookQueryModel): Observable<ReqViewModel> {
    return this.httpClient.post<ReqViewModel>(`${this.api}book/get`, model);
  }

  takeBook(userId: string, bookId: number): Observable<{}> {
    return this.httpClient.put(`${this.api}book/take?bookId=${bookId}&userId=${userId}`, '')
  }

  returnBook(userId: string, bookId: number): Observable<{}> {
    return this.httpClient.put(`${this.api}book/return?bookId=${bookId}&userId=${userId}`, '')
  }
  getUserBooks(id: string) : Observable <Book[]> {
    return this.httpClient.get<Book[]>(`${this.api}book/books?id=${id}`);
  }
}
