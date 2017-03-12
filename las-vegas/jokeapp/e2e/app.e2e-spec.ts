import { JokeappPage } from './app.po';

describe('jokeapp App', () => {
  let page: JokeappPage;

  beforeEach(() => {
    page = new JokeappPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
