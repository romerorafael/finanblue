import { Product } from "../product/product";

export interface Purchase {
    id: number,
    companyId: number,
    total: number,
    products: Product[],
}

export interface PurchaseBody{
    purchase: Purchase,
    products: Product[]
}