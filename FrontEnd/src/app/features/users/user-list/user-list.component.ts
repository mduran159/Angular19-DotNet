import { Component } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import { User } from '../models/user.model';
import { UserService } from '../services/user.service';
import { MatDialog } from '@angular/material/dialog'
import { MatIconModule } from '@angular/material/icon';
import { Router } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ConfirmationDialogComponent } from '../../../shared/confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-user-list',
  imports: [MatTableModule, MatIconModule, MatButtonModule, MatFormFieldModule, MatInputModule, CommonModule, FormsModule],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})

export class UserListComponent {
  searchValue: string = ''
  displayedColumns: string[] = ['firstName', 'lastName', 'country', 'phone', 'email', 'actions'];
  originalDataSource: User[] = [];
  filteredDataSource: User[] = [];

  constructor(private userService: UserService, private router: Router, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe({
      next: (users) => {
        this.originalDataSource = users;
        this.filteredDataSource = users;
      },
      error: (error) => {
        console.error('Error al cargar los usuarios:', error);
      },
      complete: () => {
        console.log('Carga de usuarios completada.');
      }
    });
  }

  filterResults() {
    var text = this.searchValue.trim();
    if (!text) {
      this.filteredDataSource = this.originalDataSource;
      return;
    } 

    const searchText = text.toLowerCase();

    this.filteredDataSource = this.originalDataSource.filter(user =>
      user?.firstName.toLowerCase().includes(searchText) ||
      user?.lastName.toLowerCase().includes(searchText) ||
      user?.email.toLowerCase().includes(searchText)
    );
  }
  
  editUser(id: string): void {
    this.router.navigate(['/edit', id]);
  }

  deleteUser(id: string): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      width: '350px',
      data: { message: 'Are you sure you want to delete this user?' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.userService.deleteUser(id).subscribe({
          next: () => {
            console.log(`User with ID ${id} deleted successfully.`);
            this.filteredDataSource = this.filteredDataSource.filter((user) => user.id !== id);
          },
          error: (error) => {
            console.error('Error deleting user:', error);
          },
        });
      }
    });
  }

  createNew(): void {
    this.router.navigate(['/create']); // Cambia la ruta según tu necesidad
  }
}