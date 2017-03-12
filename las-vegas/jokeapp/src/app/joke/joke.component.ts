import { Component, OnInit } from '@angular/core';
import {Joke} from './models/joke.model';

@Component({
  selector: 'app-joke',
  templateUrl: './joke.component.html',
  styleUrls: ['./joke.component.css']
})
export class JokeComponent implements OnInit {

  private joke: Joke;

  constructor() {
    this.joke = new Joke(1, "Why did the baby cross the road?", "Because it was stapled to the chicken!", [], 0, 0);

}

  ngOnInit() {
  }

}
