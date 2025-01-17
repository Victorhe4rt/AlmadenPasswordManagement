import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-modal-view-component',
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
  templateUrl: './modal-view-component.component.html',
  styleUrls: ['./modal-view-component.component.css']
})
export class ModalViewComponentComponent {
  url: string = '';
  name: string = '';
  pk_UserId: number = 0;
  userName: string = '';
  password: string = '';
  isPasswordVisible: boolean = false;

  constructor(
    public dialogRef: MatDialogRef<ModalViewComponentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.url = data.url;
    this.name = data.name;
    this.pk_UserId = data.pk_UserId;
    this.userName = data.userName;
    this.password = data.password;
  }

  togglePasswordVisibility(): void {
    this.isPasswordVisible = !this.isPasswordVisible;
  }

  closeDialog(): void {
    this.dialogRef.close();
  }
}
