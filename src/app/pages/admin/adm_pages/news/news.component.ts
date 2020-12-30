import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NewsService } from '@app/services/news.service';

/* istanbul ignore next */
@Component({
  selector: 'app-anews',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss']
})
export class AdminNewsComponent implements OnInit {
  newsDataForm: FormGroup;
  fobj: any = {type: 'image', src: ''};
  
  constructor(private fb: FormBuilder, private newsSrv: NewsService) { 
  }

  ngOnInit(): void {
    this.initNewsData();
  }

  get f() { return this.newsDataForm.controls; }

  getDateToday() {
    var dt = new Date();
    var ndy = dt.getFullYear(), ndm = (dt.getMonth()+1), ndd = dt.getDate(), 
        ndh = (dt.getHours() < 10) ? '0' + dt.getHours() : dt.getHours(), 
        ndmi = (dt.getMinutes() < 10) ? '0' + dt.getMinutes() : dt.getMinutes(),
        nds = (dt.getSeconds() < 10) ? '0' + dt.getSeconds() : dt.getSeconds();
    return ndy + "-" + ndm + "-" + ndd + "T" + ndh + ":" + ndmi + ":" + nds;
  }

  initNewsData() {
    var cuinfo = JSON.parse(localStorage.getItem('currentUser'));
    var cuid = (cuinfo) ? cuinfo.id : 1;

    this.newsDataForm = this.fb.group({
      title: ['', Validators.required],
      desc: ['', Validators.required],
      date: [this.getDateToday(), Validators.required],
      cover: ['cover.jpg', Validators.required],
      category: ['', Validators.required],
      text: ['', Validators.required],
      source: ['', Validators.required],
      usersId: [cuid]
    });

    this.fobj.src = this.f.cover.value;

    this.newsSrv.ObsGetNews().subscribe((x: any) => {
      this.f.source.setValue('/news/'+(x.length+1));
    });
  }

  changeFile(event: any) {
    this.fobj = event;
    this.f.cover.setValue(this.fobj.src);
  }

  onSubmit(event: any) {
    event.preventDefault();
    
    var obj: any = {
      title: this.f.title.value,
      desc: this.f.desc.value,
      date: this.f.date.value,
      cover: 'https://localhost:5001/resources/images/'+this.f.cover.value,
      category: this.f.category.value,
      text: this.f.text.value,
      source: this.f.source.value,
      usersId: this.f.usersId.value
    };

    this.newsSrv.insertNews(obj).subscribe(
      ninfo => console.log(ninfo), 
      error => console.log(error)
    );
  }
}
