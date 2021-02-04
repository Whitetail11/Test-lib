import { Author } from "./Author";
import { User } from "./User";

export interface Book {
    id: number,
    name: string,
    amount: number,
    available: number,
    authors: Author[],
    users: User[]
}