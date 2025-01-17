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

  passwords = [
    { title: 'Google', username: 'user1@gmail.com', password: '123456' },
    { title: 'Facebook', username: 'user2@fb.com', password: 'abcdef' },
    { title: 'Twitter', username: 'user3@twitter.com', password: 'qwerty' },
    { title: 'GitHub', username: 'dev@github.com', password: 'githubpass' },
    { title: 'LinkedIn', username: 'user@linkedin.com', password: 'linkedin123' }
  ];

  get filteredPasswords() {
    return this.passwords.filter(p =>
      p.title.toLowerCase().includes(this.searchText.toLowerCase()) ||
      p.username.toLowerCase().includes(this.searchText.toLowerCase())
    );
  }

  constructor(public dialog: MatDialog, private cdr: ChangeDetectorRef) {}

  ngAfterViewInit() {
    this.cdr.detectChanges(); // Força a detecção de mudanças após o modal ser fechado
  }

  addNewPassword() {
    const dialogRef = this.dialog.open(ModalAddComponentComponent, {
      width: '400px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // Aqui você pode salvar o novo password no seu array ou enviar para o backend
        this.passwords.push(result);
        console.log('New password added:', result);
      }
    });
  }
}
