export interface CreateSaleRequestDto {
  customerId: string;
  customerName: string;
  branchId: string;
  branchName: string;
  saleItems: CreateSaleItemRequestDto[];
}

export interface CreateSaleItemRequestDto {

  ProductId: string;
  ProductName: string;
  Quantity: number;
  UnitPrice: number;
  Discount: number 
  TotalPrice: number             
}


