import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrdenDTO } from 'src/app/services/models/orden';
import { OrdenService } from 'src/app/services/orden.service';
import { PaymentService } from 'src/app/services/payment.service';

@Component({
  selector: 'app-confirmacion',
  templateUrl: './confirmacion.component.html',
  styleUrls: ['./confirmacion.component.css']
})
export class ConfirmacionComponent implements OnInit {
  transaccion: any;
  orden: OrdenDTO;
  icon:string ;
  class:string;
  estado:string;
  constructor(private activate: ActivatedRoute,
              private ordenService: OrdenService,
              private paymentService: PaymentService,
              private router: Router) { }

  ngOnInit(): void {
    this.activate.params.subscribe(param => {
      this.getOrden(param.id);
    });
  }

  getOrden(id: number): void {
    this.ordenService.getOrdenesById(id).subscribe({
      next:(data) => {
        this.orden = data;
        this.getTransaction(Number(this.orden.TransactionId));
      }
    });
  }

  getTransaction(id: number): void {
    this.paymentService.getTransactionState(id).subscribe({
      next:(data) => {
        this.transaccion = data;
        console.log(data);
        switch (this.transaccion.status.status) {
          case 'APPROVED':
            this.icon = 'check_circle';
            this.class = 'text-success';
            this.estado = "PAYED";
            break;
          case 'PENDING':
            this.icon = 'info';
            this.class = 'text-warning';
            this.estado = "CREATED";
            break;
          case 'REJECTED':
            this.icon = 'highlight_off';
            this.class = 'text-danger';
            this.estado = "REJECTED";
            break;
        }
      }
    }

    );
  }

  irPedidos(): void {
    this.actualizarEstado();
    this.router.navigateByUrl('listado');
  }

  actualizarEstado(): void {
    this.orden.Status = this.estado;
    this.orden.UpdateAt = new Date();
    this.ordenService.saveOrden(this.orden).subscribe();
  }

}
