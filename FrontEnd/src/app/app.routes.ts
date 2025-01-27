import { Routes } from '@angular/router';
import { UserFormComponent } from './features/users/user-form/user-form.component';
import { UserListComponent } from './features/users/user-list/user-list.component';

export const routes: Routes = [
    {
        path: '',
        component: UserListComponent,
        title: 'Users List'
    },
    {
        path: 'create',
        component: UserFormComponent,
        title: 'Create User',
      },
      {
        path: 'edit/:id',
        component: UserFormComponent,
        title: 'Edit User',
      },
];