import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {environment} from '../../environments/environment'
import { Observable } from 'rxjs';
import { RequestPaymentDTO } from './models/payment/requestPayment';

@Injectable({providedIn: 'root'})
export class PaymentService {
    private urlService: string;

    constructor(private client: HttpClient) { 
        this.urlService = `${environment.urlBackService}/PlacetoPay`;
    }
    /**
     * Inicia la sesión para generar enlace de redirección a la pasarela de pagos
     */
    startSession(request: RequestPaymentDTO): Observable<any>{
        return this.client.post(`${this.urlService}/StartSession`,request);
    }

    /**
     * Obtiene el estado de la transacción
     */
    getTransactionState(id: number): Observable<any> {
        return this.client.get(`${this.urlService}/SearchTransaction?id=${id}`);
    }
    
}