import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginComponent } from 'src/app/login/login.component';
import { AuthService } from 'src/app/services/auth.service';
import { Producto } from 'src/app/services/models/producto';
import { PaymentService } from 'src/app/services/payment.service';
import { ProductoService } from 'src/app/services/producto.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent implements OnInit {
  productos: Observable<Producto[]>;
  texto = '';
  data: Producto[];
  constructor(private service: ProductoService,
              public dialog: MatDialog,
              private router: Router) { 
    
  }

  ngOnInit(): void {
      this.getproductos();
      var usuario = sessionStorage.getItem('usuario');
      if(usuario == null) {
        this.modalLogin();
      }
  } 

  modalLogin(): void {
    this.dialog.open(LoginComponent, {
      width: '30vw',
      disableClose: true
    });
  }
  
  getproductos(){
     this.productos = this.service.getProductos();
  }

  comprar(producto: Producto) {
    Swal.fire({
      title: 'Confirmación de Compra',
      text: `Esta seguro de comprar el producto ${producto.NombreProducto}`,
      showCancelButton: true,
      showCloseButton: true,
      showConfirmButton: true,
      confirmButtonText: 'Comprar',
      cancelButtonText: 'Cancelar'
    }).then(result => {
      if(result.value) {
        sessionStorage.setItem('producto', JSON.stringify(producto));
        this.router.navigateByUrl('resumen');
      }
    })
    console.log(producto);
  }
}


