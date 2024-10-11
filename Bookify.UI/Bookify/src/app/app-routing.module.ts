import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddAuthorComponent } from './components/auth/add-author/add-author.component';
import { AddBookComponent } from './components/auth/add-book/add-book.component';
import { AddBookshopComponent } from './components/auth/add-bookshop/add-bookshop.component';
import { AuthorsComponent } from './components/auth/authors/authors.component';
import { BooksComponent } from './components/auth/books/books.component';
import { BookshopsComponent } from './components/auth/bookshops/bookshops.component';
import { CategoriesComponent } from './components/auth/categories/categories.component';
import { DashboardComponent } from './components/auth/dashboard/dashboard.component';
import { AboutusComponent } from './components/index/aboutus/aboutus.component';
import { ConfirmationComponent } from './components/index/confirmation/confirmation.component';
import { HomeComponent } from './components/index/home/home.component';
import { LoginComponent } from './components/index/login/login.component';
import { RegisterComponent } from './components/index/register/register.component';

const routes: Routes = [
  // Default Sidebar Nav Components
  {
    path: "",
    component: HomeComponent,
    children: [
      {
        path: 'login',
        component: LoginComponent
      },
      {
        path: 'register',
        component: RegisterComponent
      },
      {
        path: 'aboutus',
        component: AboutusComponent
      },
      {
        path: 'confirm',
        component: ConfirmationComponent
      }
    ]
  },
  // Auth Routes
  {
    path: "auth",
    component: DashboardComponent,
    children: [
      {
        path: 'books',
        component: BooksComponent
      },
      {
        path: 'book',
        component: AddBookComponent
      },
      {
        path: 'book/:id',
        component: AddBookComponent
      },
      {
        path: 'bookshops',
        component: BookshopsComponent
      },
      {
        path: 'bookshop',
        component: AddBookshopComponent
      },
      {
        path: 'bookshop/:id',
        component: AddBookshopComponent
      },
      {
        path: 'authors',
        component: AuthorsComponent
      },
      {
        path: 'author',
        component: AddAuthorComponent
      },
      {
        path: 'author/:id',
        component: AddAuthorComponent
      },
      {
        path: 'categories',
        component: CategoriesComponent
      },
    ]
  },
  // Default Routes
  {path: "", component: HomeComponent},
  {path: "**", redirectTo: "", pathMatch: "full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
