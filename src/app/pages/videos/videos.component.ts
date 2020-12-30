import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-videos',
  templateUrl: './videos.component.html',
  styleUrls: ['./videos.component.scss']
})
export class VideosComponent implements OnInit {
  options: any;

  constructor() { }

  ngOnInit(): void {
    this.options = {
      autoplay: false,
      fluid: true,
      responsive: true,
      controls: true
    };
  }

}
