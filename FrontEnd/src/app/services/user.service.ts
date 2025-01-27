import { Injectable } from '@angular/core';
import { User } from '../shared/models/user.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class UserService {
  private readonly apiBaseUrl = 'http://localhost:5181/api/Users';

  constructor(private http: HttpClient) {}

  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiBaseUrl);
  }

  getUserById(userId: string): Observable<User> {
    return this.http.get<User>(`${this.apiBaseUrl}/${userId}`);
  }

  deleteUser(userId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiBaseUrl}/${userId}`);
  }

  createUser(user: User): Observable<User> {
    return this.http.post<User>(this.apiBaseUrl, user);
  }

  updateUser(user: User): Observable<User> {
    return this.http.put<User>(`${this.apiBaseUrl}/${user.id}`, user);
  }

  getGenders(): Observable<string[]> {
    return this.http.get<string[]>(`${this.apiBaseUrl}/Genders`);
  }

  getCountries(): Observable<string[]> {
    return this.http.get<string[]>(`${this.apiBaseUrl}/Countries`);
  }
}