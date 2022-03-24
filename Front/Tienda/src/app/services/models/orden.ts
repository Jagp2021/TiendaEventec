import { DetalleOrden } from "./detalleOrden";

export interface OrdenDTO {
    Id?: number;
    CustomerName?: string;
    CustomerEmail?: string;
    CustomerMobile?: string;
    Status?: string;
    CreateAt?: Date;
    UpdateAt?: Date;
    TransactionId?: string;
    DetalleOrden?: DetalleOrden[];
}