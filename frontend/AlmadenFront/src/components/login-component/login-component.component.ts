import { ApplicationModule, Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserServiceService } from '../services/user-service.service';
import { User } from '../interface/User';
import { FormsModule } from '@angular/forms'
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-component',
  standalone: true,
  templateUrl: './login-component.component.html',
  styleUrls: ['./login-component.component.css'],
  imports: [
    CommonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatCheckboxModule,
    FormsModule,

  ]
  
})
export class LoginComponentComponent {
  username: string = '';
  password: string = '';

  constructor(
    private userService: UserServiceService,
    private snackBar: MatSnackBar,
    private router: Router 

  ) {}

  onLogin(): void {
    const user: User = {
      userName: this.username,
      password: this.password
    };

    this.userService.authenticate(user).subscribe({
      next: (response) => {
        if (response.status === 200) {
          console.log('Userid', response.body.data); 
         
          sessionStorage.setItem('username', response.body.data); 

          this.showSnackbar('User logged with success', 'success-snackbar');
          this.router.navigate(['/home']); 
        } else {
          console.error('Unexpected status:', response.status);
          this.showSnackbar('Unexpected error occurred', 'error-snackbar');
        }
      },
      error: (error) => {
        console.error('Error:', error); 
        this.showSnackbar('Username/password invalid', 'error-snackbar');
      }
    });
    
    
  }

  private showSnackbar(message: string, panelClass: string): void {
    this.snackBar.open(message, 'Close', {
      duration: 3000,
      panelClass: [panelClass]
    });
  }
}
