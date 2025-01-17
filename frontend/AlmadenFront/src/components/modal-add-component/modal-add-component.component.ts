import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog'
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { LastPassCardServiceService } from '../services/last-pass-card-service.service';
import { LastPassCard } from '../interface/LastPassCard';
import { MatSnackBar } from '@angular/material/snack-bar';
import {Router, NavigationEnd,ActivatedRoute} from '@angular/router';


import { FormsModule } from '@angular/forms'

// import { MatTextareaModule } from '@angular/material/textarea';

@Component({
  selector: 'app-modal-add-component',
  standalone: true,
  imports: [
    MatDialogModule,
    MatFormFieldModule, 
    MatInputModule, 
    MatButtonModule,
    MatIconModule, 
    CommonModule,
    MatCardModule,
    MatCheckboxModule,
    FormsModule,
  ],
  templateUrl: './modal-add-component.component.html',
  styleUrl: './modal-add-component.component.css',
 
})
export class ModalAddComponentComponent {
  id: number = 0; 

  url: string = '';
 
  name: string = '';
  pk_UserId: number = 0; 
  userName: string = '';
  password: string = '';
  currentComponent = ''; 
 


  constructor(public dialogRef: MatDialogRef<ModalAddComponentComponent> ,
    private lastPassCardService: LastPassCardServiceService,
    private snackBar: MatSnackBar,
    private router: Router, 
    private activatedRoute: ActivatedRoute
  
  ) {}

  closeDialog(): void {
    this.dialogRef.close();
  }

  savePassword(): void {

    const newPassword: LastPassCard = {
      id: this.id,
      url: this.url,
      name: this.name,
      pk_UserId: Number(sessionStorage.getItem('username')),
      userName: this.userName,
      password: this.password,
    };
    
    this.lastPassCardService.createLastPassCard(newPassword).subscribe({
      next: (response) => {
        console.log('Password saved successfully:', response);
        this.showSnackbar('Card added with success', 'success-snackbar');
        
        this.dialogRef.close(newPassword);
      },
      error: (err) => {
        console.error('Error saving password:', err);
        this.showSnackbar('Error saving password', 'error-snackbar'); 
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
