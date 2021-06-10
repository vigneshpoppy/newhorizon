import { Component, OnInit } from '@angular/core';
import{Router,ActivatedRoute,ParamMap} from '@angular/router';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor( private route:Router){
    route.navigate(['/home']);

  }
  name:string="";
  ngOnInit(): void {
    //throw new Error('Method not implemented.');
   // this.route.queryParams.subscribe(params =>{this.name='home'});
  }
  title = 'routingDemo';
}
