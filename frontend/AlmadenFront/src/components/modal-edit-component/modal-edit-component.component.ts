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
import { LastPassCardServiceService } from '../services/last-pass-card-service.service';
import { LastPassCard } from '../interface/LastPassCard';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, ActivatedRoute } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-modal-edit-component',
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
  templateUrl: './modal-edit-component.component.html',
  styleUrls: ['./modal-edit-component.component.css']
})
export class ModalEditComponentComponent {

  isPasswordVisible: boolean = false;
  id: number = 0;
  url: string = '';
  name: string = '';
  pk_UserId: number = 0;
  userName: string = '';
  password: string = '';
  currentComponent = '';

  constructor(
    public dialogRef: MatDialogRef<ModalEditComponentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: LastPassCard,
    private lastPassCardService: LastPassCardServiceService,
    private snackBar: MatSnackBar,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    // Inicializando os valores a partir dos dados passados para o modal
    this.id = data.id;
    this.url = data.url;
    this.name = data.name;
    this.pk_UserId = data.pk_UserId;
    this.userName = data.userName;
    this.password = data.password;
  }

  closeDialog(): void {
    this.dialogRef.close();
  }

  private showSnackbar(message: string, panelClass: string): void {
    this.snackBar.open(message, 'Close', {
      duration: 3000,
      panelClass: [panelClass],
    });
  }

  editPassword(): void {
    if (!this.id) {
      this.showSnackbar('Invalid item!', 'error');
      return;
    }

    const updatedCard: Omit<LastPassCard, 'id'> = {
      url: this.url,
      name: this.name,
      pk_UserId: this.pk_UserId,
      userName: this.userName,
      password: this.password
    };

    this.lastPassCardService.updateLastPassCard(this.id, updatedCard).subscribe({
      next: () => {
        this.showSnackbar('Card updated successfully!', 'success');
        this.dialogRef.close(updatedCard); 
      },
      error: (err) => {
        console.error('Error updating card:', err);
        this.showSnackbar('Error updating card.', 'error');
      }
    });

  }

  togglePasswordVisibility(): void {
    this.isPasswordVisible = !this.isPasswordVisible;
  }
}
