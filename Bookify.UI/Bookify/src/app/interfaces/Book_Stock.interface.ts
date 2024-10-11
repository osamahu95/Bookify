import { Stock } from "../models/Stock.model";

export interface BookStock{
    stock: Stock,
    bookId: string
}