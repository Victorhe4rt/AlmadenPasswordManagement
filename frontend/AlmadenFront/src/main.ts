import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideRouter } from '@angular/router';
import { routes } from './app/app.routes';
import { AppComponent } from './app/app.component';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { LoginComponentComponent } from './components/login-component/login-component.component';

bootstrapApplication(AppComponent, {
  providers: [
    provideHttpClient(), 
    provideAnimations(), 
    provideRouter(routes), 
    MatButtonModule,      
    MatInputModule,       
    MatIconModule,        
    MatCardModule,         
    MatFormFieldModule,  
     
  ]
}).catch((err) => console.error(err));
