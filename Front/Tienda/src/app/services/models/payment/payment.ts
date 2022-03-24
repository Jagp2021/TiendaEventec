export interface PaymentDTO {
    reference?: string;
    description?: string;
    amount?: AmountDTO;
    allowpartial?: boolean;
}

export interface AmountDTO {
    currency?: string;
    total?: number;
}