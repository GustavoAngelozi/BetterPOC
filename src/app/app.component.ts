import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'BetterPOC';

  constructor(private banana: DataService) { }

  ngOnInit(): void {
    console.log("oi")
    this.banana.getData().subscribe(val => {
      console.log(val)
    })
  }
}
