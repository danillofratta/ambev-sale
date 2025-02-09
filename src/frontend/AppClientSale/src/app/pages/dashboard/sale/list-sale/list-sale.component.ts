import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Observable, catchError, finalize, map } from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { SaleApi } from '../../../../../domain/api/SaleApi';
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

  public _ListError: string[] = [];

  dataSource = new MatTableDataSource<GetSaleResponseDto>();

  displayedColumns = ['actions', 'id', 'number', 'customerName', 'branchName', 'status', 'totalAmount'];

  @ViewChild(MatPaginator) paginator: any = MatPaginator;
  
  constructor(private Api: SaleApi, private router: Router) {
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  async ngOnInit() {
    this.busy = true;

    await this.LoadList();
  }

  ClearErrorList() {
    this._ListError = [];
  }

  async LoadList() {

    await new Promise(resolve => setTimeout(resolve, 3000));

    this.busy = true;
    
    this.list$ = (await this.Api.GetListAll()).pipe(
      map(response => response.data.items),
      catchError((error) => {
        console.error('Error fetching data:', error);
        return [];
      })
    );

    await this.list$.subscribe({
      next: (items) => {
        this.dataSource.data = items;
        this.busy = false;
      },
      error: (error) => {
        console.error('Error loading data:', error);
        this.busy = false;
      }
    });

    this.busy = false;
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
    this.ClearErrorList();
    const record: CancelSaleResponseDto = { Id: id }

    await (await this.Api.Cancel(record)).subscribe({
      next: (response) => {
        if (response.success) {
          this.router.navigate(['/sale']);
        } else {
          this._ListError.push(response.message);
        }
      },
      error: (error) => {
        console.error('Error occurred:', error);
        
        this._ListError.push(error.error.message);
      },
      complete: () => {
        this.busy = false; 
      }
    });
    
    this.LoadList();

    this.busy = false;
  }

  async onModify(id: string) {
    this.router.navigate(['/sale/modify/' + id]);    
  }
}


