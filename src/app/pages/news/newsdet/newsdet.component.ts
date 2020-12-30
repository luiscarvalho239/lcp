import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { News } from 'src/app/classes/news';
import { NewsService } from 'src/app/services/news.service';

@Component({
  selector: 'app-newsdet',
  templateUrl: './newsdet.component.html',
  styleUrls: ['./newsdet.component.scss']
})
export class NewsdetComponent implements OnInit {
  newsdet$: Observable<News[]>;
  getDataNewsDet$: Observable<News[]> = new Observable<News[]>();
  id: number = -1;

  constructor(private newsServ: NewsService, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.getDataNewsDet$ = this.newsServ.ObsGetNews(this.id);
    this.newsdet$ = this.getDataNewsDet$;
  }

}
