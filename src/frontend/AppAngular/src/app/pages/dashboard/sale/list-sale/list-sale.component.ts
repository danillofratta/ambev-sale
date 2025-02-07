import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Observable, catchError, finalize, map } from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { SaleApi } from '../../../../../domain/api/SaleApi';
import { FormBuilder } from '@angular/forms';
import { SignalRSaleService } from '../../../../../domain/signalr/SignalRSaleService';
import { GetSaleResponseDto } from '../../../../../domain/dto/sale/get/GetSaleResponseDto';
import { Router } from '@angular/router';
import { CancelSaleResponseDto } from '../../../../../domain/dto/sale/cancel/CancelSaleResponseDto';

@Component({
  selector: 'app-list-sale',
  templateUrl: './list-sale.component.html',
  styleUrl: './list-sale.component.css'
})
export class ListSaleComponent implements OnInit, AfterViewInit {

  public list$: Observable<GetSaleResponseDto[]> = new Observable<GetSaleResponseDto[]>();
  
  public busy = false;
  isLoading: boolean = true;

  dataSource = new MatTableDataSource<GetSaleResponseDto>();

  displayedColumns = ['actions', 'id', 'customerName', 'branchName', 'Status', 'totalAmount'];

  @ViewChild(MatPaginator) paginator: any = MatPaginator;
  
  constructor(private Api: SaleApi, private router: Router, private fb: FormBuilder, private signalRService: SignalRSaleService) {
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  async ngOnInit() {
    this.isLoading = true;

    await this.LoadList();

    //this.signalRService.onGetListSaleUpdated((updatedDataList) => {
    //  console.log('Lista de dados recebida:', updatedDataList);

    //  const orders$: Observable<ListSaleResponseDto[]> = of(updatedDataList as ListSaleResponseDto[]);

    //  console.log(orders$);

    //  this.list$ = orders$;

    //  this.loadDataSource();
    //});
  }

  async LoadList() {

    this.isLoading = true;

    this.list$ = (await this.Api.GetListAll()).pipe(
      map(response => response.data.items),
      catchError((error) => {
        console.error('Error fetching data:', error);
        return [];
      })
    );

    this.list$.subscribe({
      next: (items) => {
        this.dataSource.data = items;
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error loading data:', error);
        this.isLoading = false;
      }
    });

    this.isLoading = false;
  }

  loadDataSource() {
    this.list$.subscribe(
      (item) => {
        this.dataSource.data = item;
        this.dataSource._renderChangesSubscription;
      }
    )
  }

  async onCancel(id: string) {
    this.busy = true;

    const record: CancelSaleResponseDto = { Id: id }

    await this.Api.Cancel(record);

    this.LoadList();

    this.busy = false;
  }

  async onModify(id: string) {
    this.router.navigate(['/sale/modify/' + id]);    
  }
}


