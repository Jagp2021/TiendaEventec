import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {environment} from '../../environments/environment'
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class ProductoService {
    private urlService: string;

    constructor(private client: HttpClient) { 
        this.urlService = `${environment.urlBackService}/Producto`;
    }
    /**
     * Consulta todos los productos de la tienda
     */
    getProductos(): Observable<any>{
        return this.client.get(`${this.urlService}`);
    }
}