import { Injectable } from '@angular/core';
import { API } from './API';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ProductDto } from '../dto/ProductDto';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';


@Injectable({
    providedIn: 'root'
})
export class ProductApi extends API {
   
  constructor(
    protected override http: HttpClient,    
    protected override router: Router
  ) {
    super(http, router);

    this._baseurl = environment.ApiUrlProduct;

    if (!environment.production)
      this._endpoint = '/api/v1/product/';
    else
      this._endpoint = '/product';
  }
  
  async GetListAll(): Promise<Observable<ProductDto[]>> {   
   return this._http.get<ProductDto[]>(`${this._baseurl + this._endpoint}`);
  }

  async GetById(id: number): Promise<Observable<ProductDto[]>>{   
    return this._http.get<ProductDto[]>(`${this._baseurl + this._endpoint + '/getbyid/' + id}`);
  }

  async GetByName(name: string): Promise<Observable<ProductDto[]>>{
    return this._http.get<ProductDto[]>(`${this._baseurl + this._endpoint + '/getbyname/' + name}`);
  }

  async Save(dto: ProductDto): Promise<Observable<ProductDto>> {
    return this._http.post<ProductDto>(`${this._baseurl + this._endpoint}`, dto);
   }

  async Update(dto: ProductDto): Promise<Observable<ProductDto>> {
    return this._http.put<ProductDto>(`${this._baseurl + this._endpoint}`, dto);
    }

  async Delete(id: number): Promise<Observable<void>>{
    return this._http.delete<void>(`${this._baseurl + this._endpoint +'/'+ id}`);
  }

}
