import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BooksListComponent } from 'src/components/books-list/books-list.component';
import { LoginComponent } from 'src/components/login/login.component';
import { RegistrComponent } from 'src/components/registr/registr.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegistrComponent },
  { path: '', component: BooksListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
