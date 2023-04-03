import { Product } from "../product/product";

export interface Purchase {
    id: number,
    companyId: number,
    total: number,
    products?: Product[],
    companyName?:string
}

export interface PurchaseBody{
    purchase: Purchase,
    products: Product[]
}

export interface ProductSale{
    product: Product,
    quantity: number
}