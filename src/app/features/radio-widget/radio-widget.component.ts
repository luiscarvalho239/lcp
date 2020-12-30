import { Component, OnInit } from '@angular/core';

/* istanbul ignore next */
@Component({
  selector: 'app-radio-widget',
  templateUrl: './radio-widget.component.html',
  styleUrls: ['./radio-widget.component.scss']
})
export class RadioWidgetComponent implements OnInit {
  isEnabled: boolean = false;
  isLoading: boolean = true;

  constructor() { }

  ngOnInit(): void {
  }

  loadRadio() {
    this.isLoading = true;
    this.isEnabled = !this.isEnabled;
    setTimeout(() => {
      this.isLoading = false;
    }, 0.5 * 1000);
  }
}
