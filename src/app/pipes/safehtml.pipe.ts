import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import * as DOMPurify from 'dompurify';

@Pipe({
  name: 'safeHtml'
})
export class SafehtmlPipe implements PipeTransform {

  constructor(protected sanitizer: DomSanitizer) { }

  public transform(value: any, type: string): any {
    const sanitizedContent = DOMPurify.sanitize(value, {
      ADD_TAGS: ["iframe"], //or ALLOWED_TAGS
      ADD_ATTR: ["allow", "allowfullscreen", "frameborder", "scrolling"],//or //or ALLOWED_ATR
    });
    return this.sanitizer.bypassSecurityTrustHtml(sanitizedContent);
  }
}
