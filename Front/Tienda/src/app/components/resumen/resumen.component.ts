import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OrdenDTO } from 'src/app/services/models/orden';
import { BuyerDTO } from 'src/app/services/models/payment/buyer';
import { RequestPaymentDTO } from 'src/app/services/models/payment/requestPayment';
import { ResponsePaymentDTO } from 'src/app/services/models/payment/responsePayment';
import { Producto } from 'src/app/services/models/producto';
import { OrdenService } from 'src/app/services/orden.service';
import { PaymentService } from 'src/app/services/payment.service';

@Component({
  selector: 'app-resumen',
  templateUrl: './resumen.component.html',
  styleUrls: ['./resumen.component.css']
})
export class ResumenComponent implements OnInit {
  producto: Producto;
  buyer: BuyerDTO;
  constructor(private router: Router,
              private ordenService: OrdenService,
              private pagoService: PaymentService) { }

  ngOnInit(): void {
    this.getProducto()
  }

  getProducto(): void {
    this.producto = JSON.parse(sessionStorage.getItem('producto'));
    this.buyer = JSON.parse(sessionStorage.getItem('usuario'));
    console.log(this.buyer);
  }

  cancelar(): void {
    sessionStorage.removeItem('producto');
    this.router.navigateByUrl('productos');
  }

  guardarCompra(): void {
    const request: OrdenDTO = {
      Id: 0, 
      CustomerName: this.buyer.name,
      CustomerMobile: this.buyer.mobile,
      CustomerEmail: this.buyer.email.toLowerCase(),
      Status: 'CREATED',
      CreateAt: new Date(),
      DetalleOrden: [
        {
          IdDetalle: 0,
          IdOrden: 0,
          IdProducto: this.producto.IdProducto,
          Cantidad: 1,
          Valor: this.producto.Valor
        }
      ]
    }
    this.ordenService.saveOrden(request).subscribe({
      next: (data) =>{
        this.generarPago(data);
      }
    }
    );
  }

  generarPago(orden: OrdenDTO): void {
    const request: RequestPaymentDTO = {
      buyer: this.buyer,
      payment: {
        reference: `Referencia ${orden.Id}`,
        description: 'Compra Tienda XYZ',
        allowpartial: false,
        amount: {
          currency: 'COP',
          total: this.producto.Valor
        }


      },
      returnUrl: `http://localhost:4200/#/confirmacion/${orden.Id}`
    };
    this.pagoService.startSession(request).subscribe({
      next:(data: ResponsePaymentDTO) => {
        console.log(orden);
        console.log(data);
        orden.TransactionId = data.requestId.toString();
        orden.UpdateAt = new Date();
        this.actualizarTransaccion(orden);
        const url = data.processUrl.toString();
        window.location.href = url;
      }
    });
  }

  actualizarTransaccion(orden: OrdenDTO): void {
    this.ordenService.saveOrden(orden).subscribe();
  }

}
