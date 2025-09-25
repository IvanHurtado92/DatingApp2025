import { Component, signal, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { Nav } from '../layout/nav/nav';
import { AccountService } from '../core/services/account-service';
import { Home } from "../features/home/home";
import { User } from '../types/user';

@Component({
  selector: 'app-root',
  imports: [Nav, Home],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App implements OnInit {
  private accountService = inject(AccountService);
  private http = inject(HttpClient);
  protected readonly title = signal('Dating App');
  protected members = signal<User[]>([]);

  async ngOnInit(): Promise<void> {
    this.setCurrentUser();
    this.members.set(await this.getMembers());
  }

  setCurrentUser(): void {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user = JSON.parse(userString);
    this.accountService.currentUser.set(user);
  }

  async getMembers(): Promise<User[]> {
    try {
      return lastValueFrom(this.http.get<User[]>('https://localhost:7031/api/members')); //se suscribre de otra forma 
    } catch (error) {
      console.log(error);
      throw error;
    }
  }
}
