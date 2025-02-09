//export interface ApiResponseDto<T> {
//  success: boolean;
//  message: string;
//  errors: ValidationErrorDetailDto[];
//  data?: T; // O '?' indica que pode ser undefined/null
//}

export interface ApiResponseDto<T> {
data: {
  data: T; // Aqui temos um nível extra de "data"
  success: boolean;
  message: string;
  errors: ValidationErrorDetailDto[];
};
success: boolean;
message: string;
  errors: ValidationErrorDetailDto[];
}

export interface ValidationErrorDetailDto {
  field: string;   // Nome do campo com erro (caso exista)
  message: string; // Mensagem de erro associada
}
