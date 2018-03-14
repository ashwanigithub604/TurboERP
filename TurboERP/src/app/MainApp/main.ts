import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from '../AppModule/app.module';
import { environment } from '../../environments/environment';
import { Http, Headers, RequestOptions } from '@angular/http';

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.log(err));

