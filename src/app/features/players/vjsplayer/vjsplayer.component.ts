import { Component, ElementRef, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { VideosService } from 'src/app/services/videos.service';

declare let videojs: any;

/* istanbul ignore next */
@Component({
  selector: 'app-vjsplayer',
  templateUrl: './vjsplayer.component.html',
  styleUrls: ['./vjsplayer.component.scss']
})
export class VjsplayerComponent implements OnInit, OnDestroy {
  @ViewChild('target', { static: true }) target: ElementRef;
  @Input() options: {
    fluid: boolean,
    aspectRatio: string,
    autoplay: boolean,
    responsive: boolean,
    sources: {
      type: string,
      src: string,
    }[],
  };

  pathv: string = '';
  player: any;
  ary_videos: any[] = [];

  constructor(private vidsServ: VideosService) { }

  ngOnInit() {
    this.loadDataVideos();  
  }

  loadDataVideos() {
    this.vidsServ.getVideos().subscribe((x: any) => {
      for (var dt = 0; dt < x.length; dt++) {
        this.ary_videos.push({
          src: this.pathv + x[dt].src,
          type: x[dt].type
        });
      }

      this.loadPlayer();
    }, (error) => console.log(error));
  }

  loadPlayer() {
    this.player = videojs(this.target.nativeElement, this.options, function onPlayerReady() {
      console.log('onPlayerReady', this);
    });

    this.setVideo(0);
  }

  setVideo(id = 0) {
    this.player.src({
      type: this.ary_videos[id].type,
      src: this.ary_videos[id].src
    });
  }

  ngOnDestroy() {
    if (this.player) {
      this.player.dispose();
    }
  }
}
