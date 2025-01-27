import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../models/user.model';
import { UserService } from '../services/user.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  imports: [CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    FormsModule,
    MatButtonModule],
  styleUrls: ['./user-form.component.css'],
})
export class UserFormComponent implements OnInit {
  genders: string[] = [];
  countries: string[] = [];
  user: User = {} as User;

  isEditMode: boolean = false;

  constructor(
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const userId = this.route.snapshot.paramMap.get('id');
    this.isEditMode = !!userId;
    console.log('isEditMode es = ' + this.isEditMode)

    if (this.isEditMode) {
      this.userService.getUserById(userId!).subscribe({
        next: (data) => (this.user = data),
        error: (err) => console.error('Error fetching user:', err),
      });
    }

    this.loadGenders();
    this.loadCountries();
  }

  loadGenders(): void {
    this.userService.getGenders().subscribe({
      next: (genders) => {
        this.genders = genders;
      },
      error: (error) => {
        console.error('Error loading genders:', error);
      },
    });
  }

  loadCountries(): void {
    this.userService.getCountries().subscribe({
      next: (countries) => {
        this.countries = countries;
      },
      error: (error) => {
        console.error('Error loading countries:', error);
      },
    });
  }

  onSubmit(): void {
    if (this.isEditMode) {
      this.userService.updateUser(this.user).subscribe({
        next: () => {
          console.log('User updated successfully');
          this.router.navigate(['/']);
        },
        error: (err) => console.error('Error updating user:', err),
      });
    } else {
      this.userService.createUser(this.user).subscribe({
        next: () => {
          console.log('User created successfully');
          this.router.navigate(['/']);
        },
        error: (err) => console.error('Error creating user:', err),
      });
    }
  }

  onCancel(): void {
    this.router.navigate(['/']);
  }
}
