import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-upvote',
  templateUrl: './upvote.component.html',
  styleUrls: ['./upvote.component.css']
})
export class UpvoteComponent implements OnInit {
  @Input() votes: number;

  @Output() incrementVotes = new EventEmitter();

  constructor() { }

  incrementVoteCount() {
    this.incrementVotes.emit();
  }

  ngOnInit() {
  }

}
