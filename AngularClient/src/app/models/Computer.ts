import { User } from './User';
import { Scheduling } from './Scheduling';

export interface Computer {
    id: number,
    name: string;
    ip: string;
    os: string;
    username: string;
    diskSpace: string;
    memoryInfo: string;
    userId: string;
    user: User;
    schedulings: Scheduling[];
}
