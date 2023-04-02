import { Product } from "../product/product";

export interface Purchase {
    Id: number,
    CompanyId: number,
    Total: number,
    Products: Product[],
}

export interface PurchaseBody{
    Purchase: Purchase,
    Products: Product[]
}