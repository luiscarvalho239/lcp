import { Component, ElementRef, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { VideosService } from '@app/services/videos.service';

declare let videojs: any;
/* istanbul ignore next */
@Component({
  selector: 'app-avideos',
  templateUrl: './videos.component.html',
  styleUrls: ['./videos.component.scss']
})
export class AdminVideosComponent implements OnInit, OnDestroy {
  regVideosDataForm: FormGroup;
  submitted: boolean;
  msg: string;
  player: any;

  fobj: any = {type: 'video', src: ''};

  @ViewChild('target', { static: true }) target: ElementRef;
  // @Input() options: {
  //   fluid: boolean,
  //   aspectRatio: string,
  //   autoplay: boolean,
  //   responsive: boolean,
  //   sources: {
  //     type: string,
  //     src: string,
  //   }[],
  // };

  options = {
    autoplay: false,
    fluid: true,
    responsive: true,
    controls: true
  };

  constructor(
    private formBuilder: FormBuilder,
    private vidsSrv: VideosService
  ) {
  }

  ngOnInit() {
    this.regVideosDataForm = this.formBuilder.group({
      src: ['v1.mp4', Validators.required],
      type: ['video/mp4', Validators.required]
    });

    this.fobj.src = this.f.src.value;
    this.loadPlayer();
  }

  get f() { 
      return this.regVideosDataForm.controls; 
  }

  loadPlayer() {
    this.player = videojs(this.target.nativeElement, this.options, function onPlayerReady() {
      console.log('onPlayerReady', this);
    });

    this.player.src({
      type: this.f.type.value,
      src: 'assets/videos/'+this.f.src.value
    });
  }

  ngOnDestroy() {
    if (this.player) {
      this.player.dispose();
    }
  }

  changeFile(event: any) {
    this.fobj = event;
    this.f.src.setValue(this.fobj.src);
  }

  resetForm(event: any) {
    event.preventDefault();

    this.regVideosDataForm.reset();
    this.regVideosDataForm.clearValidators();
    this.regVideosDataForm.markAsPristine();
    this.f.src.setValue('v1.mp4');
    this.f.type.setValue('video/mp4');
    this.fobj = {type: 'video', src: this.f.src.value};
  }

  onSubmit(event: any) {
    event.preventDefault();
    this.submitted = true;

    const obj = { 
      src: 'https://localhost:5001/resources/videos/'+this.f.src.value,
      type: this.f.type.value
    };

    this.vidsSrv.addVideos(obj).subscribe(res => {
      this.msg = 'The video ' + this.f.src.value + ' has been added';
      setTimeout(() => {
        location.href = location.href;
      }, 60 * 1000);
    }, (err: any) => { this.msg = err; });
  }
}
