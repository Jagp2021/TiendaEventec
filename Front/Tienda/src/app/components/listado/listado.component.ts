import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { OrdenDTO } from 'src/app/services/models/orden';
import { BuyerDTO } from 'src/app/services/models/payment/buyer';
import { OrdenService } from 'src/app/services/orden.service';

@Component({
  selector: 'app-listado',
  templateUrl: './listado.component.html',
  styleUrls: ['./listado.component.css']
})
export class ListadoComponent implements OnInit {
  displayedColumns: string[] = ['Id', 'Status','CreateAt', 'Acciones'];
  dataSource: MatTableDataSource<OrdenDTO>;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  usuario: BuyerDTO;
  ordenes: OrdenDTO[];
  constructor(private service: OrdenService) { }

  ngOnInit(): void {
    this.usuario = JSON.parse(sessionStorage.getItem('usuario'));
    this.getListado();
  }

  getListado(): void {
    this.service.getOrdenes().subscribe({
      next:(data:OrdenDTO[]) => {
        this.ordenes = data.filter(x => x.CustomerEmail === this.usuario.email.toLowerCase());
        this.dataSource = new MatTableDataSource(this.ordenes);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
