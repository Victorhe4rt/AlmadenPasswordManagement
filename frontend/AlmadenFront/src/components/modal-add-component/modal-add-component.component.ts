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
  url: string = '';
  name: string = '';
  pk_UserId: number = 1; 
  userName: string = '';
  password: string = '';
  // notes: string = '';


  constructor(public dialogRef: MatDialogRef<ModalAddComponentComponent>) {}

  closeDialog(): void {
    this.dialogRef.close();
  }

  savePassword(): void {
    const newPassword = {
      url: this.url,
      name: this.name,
      pk_UserId: this.pk_UserId,
      userName: this.userName,
      password: this.password,
      // notes: this.notes
    };
    console.log('Password saved', newPassword);
    this.dialogRef.close(newPassword);
  }

}
