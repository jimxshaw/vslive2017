export class Vote {
    constructor(public count: number) {}

    public voteCount(): number {
        return this.count;
    }

    public increment(): void {
        this.count++;
    }

    public decrement(): void {
        this.count--;
    }
}