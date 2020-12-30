import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { UploadService } from '@app/services/upload.service';

/* istanbul ignore next */
@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss']
})
export class UploadComponent implements OnInit {
  fileData: File = null;
  @Input('fobj') fobjvar: any = {type: 'image', src: ''};
  @Output('changeFile') changeFile: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('myfile') myFile: ElementRef;

  constructor(private uplSrv: UploadService) { }

  ngOnInit(): void {
    this.emitData(this.fobjvar.type, this.fobjvar.src);
  }

  emitData(type: string, src: string) {
    this.changeFile.emit({type: type, src: src});
  }

  onFileSelect(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.fileData = file;
      this.emitData(this.fobjvar.type, this.fileData.name);
      this.upload();
    }
  }

  upload() {
    const formData = new FormData();
    formData.append('file', this.fileData);

    this.uplSrv.upload(formData, this.fobjvar.type).subscribe(
      (res: any) => console.log(res),
      (err: any) => console.log(err)
    );

    this.myFile.nativeElement.value = '';
  }
}
