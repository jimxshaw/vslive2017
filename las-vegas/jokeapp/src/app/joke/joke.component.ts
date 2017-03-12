import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-joke',
  templateUrl: './joke.component.html',
  styleUrls: ['./joke.component.css']
})
export class JokeComponent implements OnInit {

  private message: string = "hello earth ";

  constructor() {
    let date = new Date();
    this.message += date.toDateString();
  }

  ngOnInit() {
  }

}
