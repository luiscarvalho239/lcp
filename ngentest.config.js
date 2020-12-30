// const fs = require('fs');
// const path = require('path');

module.exports = {
  framework: 'karma',
  directives: [], 
  pipes: [],
  replacements: [
    { from: 'require\\("html-custom-element"\\)', to: '{}'},
    { from: '^\\S+\\.define\\(.*\\);', to: ''}
  ],
  providerMocks: {
    ElementRef: ['nativeElement = {};'],
    Router: ['navigate() {};'],
    Document: ['querySelector() {};'],
    HttpClient: ['post() {};'],
    TranslateService: ['translate() {};'],
    EncryptionService: [],
  },
  includeMatch: [/(component|directive|pipe|service).ts/],
  excludeMatch: []
}