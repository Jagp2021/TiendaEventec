import { AuthDTO } from "./auth";
import { BuyerDTO } from "./buyer";
import { PaymentDTO } from "./payment";

export interface RequestPaymentDTO {
    auth?: AuthDTO;
    locale?: string;
    buyer?: BuyerDTO;
    payment?: PaymentDTO;
    expiration?: string;
    returnUrl?: string;
    userAgent?: string;
    ipAddress?: string;
}