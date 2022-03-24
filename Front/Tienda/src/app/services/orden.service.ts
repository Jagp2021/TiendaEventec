import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {environment} from '../../environments/environment'
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class OrdenService {
    private urlService: string;

    constructor(private client: HttpClient) { 
        this.urlService = `${environment.urlBackService}/Orden`;
    }
    /**
     * Consulta todos los pedidos realizados
     */
    getOrdenes(): Observable<any>{
        return this.client.get(`${this.urlService}`);
    }

    /**
     * Consulta todos los pedidos realizados por un usuario
     */
     getOrdenesByEmail(email: string): Observable<any>{
        return this.client.get(`${this.urlService}/GetByEmail?email=${email}`);
    }

    /**
     * Consulta todos los pedidos por Id
     */
     getOrdenesById(id: number): Observable<any>{
        return this.client.get(`${this.urlService}/GetById?id=${id}`);
    }

    /**
     * Guarda una orden
     */
    saveOrden(request: any): Observable<any> {
        return this.client.post(`${this.urlService}/SaveOrden`, request);
    }
    
}