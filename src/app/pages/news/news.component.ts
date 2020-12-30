import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { News } from 'src/app/classes/news';
import { NewsService } from 'src/app/services/news.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss']
})
export class NewsComponent implements OnInit {
  news$: Observable<News[]>;
  getDataNews$: Observable<News[]> = new Observable<News[]>();
  p: number = 1;

  constructor(private newsServ: NewsService, private router: Router) {}

  ngOnInit() {
    this.getDataNews$ = this.newsServ.ObsGetNews();
    this.news$ = this.getDataNews$;
  }

  gotoItems(src: string) {
    this.router.navigate([`${src}`]);
  }
}
