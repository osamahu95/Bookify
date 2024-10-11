import { Author } from "../models/Author.model";
import { Book } from "../models/Book.model";
import { Category } from "../models/Category.model";

export interface BookInterface{
    book: Book,
    categories: Category[],
    author: Author
}