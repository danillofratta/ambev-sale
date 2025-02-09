//export interface ApiResponseListPaginationDto<T> {
//  data: {
//    items: T[];
//    totalCount: number;
//    pageNumber: number;
//    totalPages: number;
//  };
//  success: boolean;
//  message: string;
//  errors: string[];
//}

export interface ApiResponseListPaginationDto<T> {
  data: {
    items: T;
    totalCount: number;
    pageNumber: number;
    totalPages: number;
  };
  success: boolean;
  message: string;
  errors: string[];
}
