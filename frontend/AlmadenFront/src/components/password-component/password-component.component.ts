import { Component,ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider'; // Para a linha separadora
import { MatDialog } from '@angular/material/dialog';
import { ModalAddComponentComponent } from '../modal-add-component/modal-add-component.component';
import { LastPassCardServiceService } from '../services/last-pass-card-service.service';
import { LastPassCard } from '../interface/LastPassCard';
import{ModalViewComponentComponent} from'../modal-view-component/modal-view-component.component';
import{ModalEditComponentComponent} from'../modal-edit-component/modal-edit-component.component';
import{ConfirmDeleteComponentComponent} from'../confirm-delete-component/confirm-delete-component.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-password-component',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatToolbarModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule,
    MatDividerModule
  ],
  templateUrl: './password-component.component.html',
  styleUrls: ['./password-component.component.css']
})
export class PasswordComponentComponent {
  searchText: string = '';

  

  passwords: LastPassCard[] = [];

  get filteredPasswords() {
    return this.passwords.filter(p =>
      p.name.toLowerCase().includes(this.searchText.toLowerCase()) ||
      p.userName.toLowerCase().includes(this.searchText.toLowerCase())
    );
  }

  constructor(public dialog: MatDialog, 
    private cdr: ChangeDetectorRef, 
    private lastPassCardService: LastPassCardServiceService,
    private snackBar: MatSnackBar,
  ) {}


  ngOnInit(): void {
    this.loadPasswords();
  }
  ngAfterViewInit() {
    this.cdr.detectChanges(); 
  }

  addNewPassword() {
    const dialogRef = this.dialog.open(ModalAddComponentComponent, {
      width: '400px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.passwords.push(result);
        console.log('New password added:', result);
      }
    });
  }
  openViewDialog(item: any): void {
    const dialogRef = this.dialog.open(ModalViewComponentComponent, {
      width: '400px',
      data: item 
    });

    dialogRef.afterClosed().subscribe(result => {
 
    });
  }
  openEditDialog(item: any): void {
    const dialogRef = this.dialog.open(ModalEditComponentComponent, {
      width: '400px',
      data: { ...item } 
    });
  
    dialogRef.afterClosed().subscribe(updatedItem => {
      if (updatedItem) {
        const index = this.passwords.findIndex(c => c.id === updatedItem.id);
        if (index !== -1) {
          this.passwords[index] = updatedItem;
        }
      }
    });
  }
  
  
  openDeleteDialog(): void {
    const dialogRef = this.dialog.open(ConfirmDeleteComponentComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
   
        console.log('Item deleted');
      
      } else {
        console.log('Deleção cancelada');
      }
    });
  }

  loadPasswords(): void {
    const username = sessionStorage.getItem('username');
  
    if (username !== null) {
    
      const userId = parseInt(username, 10); 
  
      if (!isNaN(userId)) {
        this.lastPassCardService.getLastPassCardsByUser(userId).subscribe({
          next: (cards) => {
            this.passwords = cards;
            console.log('Passwords carregados:', this.passwords);
          },
          error: (err) => {
            console.error('Erro ao carregar passwords:', err);
          }
        });
      } else {
        console.error('Username não pode ser convertido para número');
      }
    } else {
      console.error('Nenhum username encontrado no sessionStorage');
    }
  } 
  deleteCard(item: any): void {
    const username = sessionStorage.getItem('username');
    
    if (username !== null) {
      this.lastPassCardService.deleteLastPassCard(item.id).subscribe({
        next: () => {
          this.passwords = this.passwords.filter(card => card.id !== item.id);
          this.showSnackbar('Card deleted with Sucess', 'success-snackbar');
          console.log('Cartão excluído com sucesso');
        },
        error: (err) => {
          console.error('Erro ao excluir cartão:', err);
          this.showSnackbar('Error in delete the Card', 'error-snackbar');

        }
      });
    } else {
      console.error('Nenhum username encontrado no sessionStorage');
    }
  }
  private showSnackbar(message: string, panelClass: string): void {
    this.snackBar.open(message, 'Close', {
      duration: 3000,
      panelClass: [panelClass]
    });
  }
  
}
