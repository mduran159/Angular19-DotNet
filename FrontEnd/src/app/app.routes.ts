import { Routes } from '@angular/router';
import { UserListComponent } from './user-list/user-list.component';
import { UserFormComponent } from './user-form/user-form.component';

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