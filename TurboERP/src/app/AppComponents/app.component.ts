import { Component } from '@angular/core';
import { AppService } from '../AppServices/app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [AppService],
})

export class AppComponent  {

  constructor(private _AppService: AppService) {
      
  }
  
  ngOnInit(): void {
    
     
  }
  

}
