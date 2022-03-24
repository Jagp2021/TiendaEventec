import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {environment} from '../../environments/environment'
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class AuthService {
    private urlService: string;

    constructor(private client: HttpClient) { 
        this.urlService = `${environment.urlBackService}/PlacetoPay`;
    }
    /**
     * Genera el auth del encabezado para el servicio de la pasarela de pagos
     */
    getAuthBody(): Observable<any>{
        return this.client.get(this.urlService);
    }
}