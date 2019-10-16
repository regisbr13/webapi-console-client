import { Computer } from './Computer';

export class User {
    id: number;
    login: string;
    password: string;
    computer: Computer[];
}
