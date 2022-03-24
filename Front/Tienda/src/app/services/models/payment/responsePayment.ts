export interface ResponsePaymentDTO {
    status?: StatusDTO;
    requestId?: number;
    processUrl?: string; 
}

export interface StatusDTO {
    status?: string;
    reason?: string;
    message?: string;
    date?: string;
}