import {Vote} from "./vote";

export class Joke {
    private lols: Vote = new Vote(0);
    private groans: Vote = new Vote(0);

    constructor(public setup: string, public punchline: string, public source: string) {

    }    

    public groanCount(): number {
        return this.groans.voteCount();
    }

    public addGroan(): void {
        this.groans.increment();
    }

    public lolCount(): number {
        return this.lols.voteCount();
    }

    public addLol(): void {
        this.lols.increment();
    }

    public toString(): string {
        return `${this.setup} ${this.punchline}`;
    }
}