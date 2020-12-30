import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { GeralService } from 'src/app/services/geral.service';

/* istanbul ignore next */
@Component({
  selector: 'app-lists-api',
  templateUrl: './lists_api.component.html',
  styleUrls: ['./lists_api.component.scss']
})
export class ListsApiComponent implements OnInit, AfterViewInit {
  apiItemsControl = new FormControl('', Validators.required);
  apiItemsAry: any[] = [];
  dsApi: any = [];
  dsApiCols: any = [];
  dataSource = new MatTableDataSource();

  pageSize = 10;
  pageSizeOptions: number[] = [3, 5, 10, 25, 100];

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private myServsServ: GeralService) { }

  ngAfterViewInit() {
  }

  ngOnInit(): void {
    this.myServsServ.getAllInfo().subscribe(res => {
      this.apiItemsAry = [];

      for (var v in Object.keys(res)) {
        this.apiItemsAry.push({
          value: Object.keys(res)[v]
        });
      }
    });
  }

  onChangeApiSel(event) {
    this.myServsServ.getInfoByApi(event.value).subscribe(r => {
      this.dsApi = r;
      this.dataSource = new MatTableDataSource<any>(this.dsApi);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
      this.dsApiCols = [];

      if (r.length > 0) {
        for (var v in Object.keys(r[0])) {
          this.dsApiCols.push(Object.keys(r[0])[v]);
        }
      }
    });
  }
}
