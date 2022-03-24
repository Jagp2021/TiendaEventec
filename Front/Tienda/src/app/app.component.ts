import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Tienda';
  usuario: any;
  constructor(private router: Router) {
  }

  getUsuario(): boolean {
    const user = sessionStorage.getItem('usuario');
    if(user === null) {
      return false;
    } else {

      this.usuario = JSON.parse(user);
    }
    return true;
  }

  close(): void {
    sessionStorage.removeItem("usuario");
    this.router.navigateByUrl('productos');
  }
}
