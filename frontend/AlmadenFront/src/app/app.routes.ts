import { Routes } from '@angular/router';
import {LoginComponentComponent} from '../components/login-component/login-component.component'
import {SidebarComponentComponent} from '../components/sidebar-component/sidebar-component.component'
import {PasswordComponentComponent} from '../components/password-component/password-component.component'

export const routes: Routes = [

    { path: '', component: LoginComponentComponent },
    { path: 'home', component: SidebarComponentComponent },
    { path: 'password', component: PasswordComponentComponent },
];
